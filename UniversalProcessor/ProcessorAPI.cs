using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversalProcessor.Processors;

namespace UniversalProcessor
{
    public static class ProcessorAPI
    {
        private static readonly List<DataDescriber> registeredProcessors = new List<DataDescriber>();

        static ProcessorAPI()
        {
            Queue<Tuple<Type, Type>> postmappedProcessors = new Queue<Tuple<Type, Type>>();

            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p=>p.IsSubclassOf(typeof(DataDescriber)));
            foreach (Type processor in types)
            {
                if (!(processor.GetCustomAttributes(typeof(ProcessorConfiguration), true).FirstOrDefault() is ProcessorConfiguration configAttribute))
                {
                    DataDescriber newProcessor = (DataDescriber)Activator.CreateInstance(processor);
                    registeredProcessors.Add(newProcessor);
                }
                else
                {
                    postmappedProcessors.Enqueue(new Tuple<Type, Type>(processor, configAttribute.Parent));
                }
            }

            while (postmappedProcessors.Count > 0)
            {
                Tuple<Type, Type> currentProcessorType = postmappedProcessors.Dequeue();
                DataDescriber parentProcessor = FindProcessorByType(currentProcessorType.Item2);
                if (parentProcessor != null)
                {
                    DataDescriber newProcessor = (DataDescriber)Activator.CreateInstance(currentProcessorType.Item1);
                    newProcessor.SetParent(parentProcessor, true);
                }
                else
                {
                    postmappedProcessors.Enqueue(currentProcessorType);
                }
            }
        }

        private static DataDescriber FindProcessorByType(Type type)
        {
            //TODO: search trees as well

            for (int i = 0; i < registeredProcessors.Count; i++)
            {
                if (registeredProcessors[i].GetType() == type)
                {
                    return registeredProcessors[i];
                }
            }
            return null;
        }

        public static int ProcessorCount { get => registeredProcessors.Count; }

        #region API

        public static SelfDescribingData Describe(object data)
        {
            SelfDescribingData descriptor = new SelfDescribingData(ref data);
            List<DataDescriber> describers = CanDescribe(data);
            for (int i = 0; i < describers.Count; i++)
            {
                try
                {
                    List<SDDDataViewDefinition> dataViews = describers[i].GenerateViews(data);
                    descriptor.AddRange(dataViews);
                }
                catch (Exception ex)
                {
                    descriptor.Errors.Add(ex);
                }
            }
            return descriptor;
        }

        #endregion

        private static List<DataDescriber> CanDescribe(object data)
        {
            List<DataDescriber> selected = new List<DataDescriber>();
            for (int i = 0; i < registeredProcessors.Count; i++)
            {
                if (registeredProcessors[i].CanProcess(data))
                {
                    CenDescribeChildren(data, selected, registeredProcessors[i]);
                }
            }
            return selected;
        }

        private static bool CenDescribeChildren(object data, List<DataDescriber> selected, DataDescriber processor)
        {
            if (processor.Children.Count == 0)
            {
                selected.Add(processor);
                return true;
            }

            bool childCanProcess = false;
            foreach (var childProcessor in processor.ChildNodes)
            {
                if (childProcessor.CanProcess(data))
                {
                    childCanProcess |= CenDescribeChildren(data, selected, childProcessor);
                }
            }
            if (!childCanProcess)
            {
                selected.Add(processor);
            }
            return true;
        }
    }
}
