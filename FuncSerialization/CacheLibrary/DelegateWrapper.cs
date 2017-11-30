using System;
using System.Linq;
using Newtonsoft.Json;

namespace CacheLibrary
{
    [Serializable]
    public class DelegateWrapper<TResult>
    {
        private readonly Delegate func;
        private readonly string[] jsonParameters;

        public DelegateWrapper(Delegate func, params object[] parameters)
        {
            this.func = func;
            this.jsonParameters = parameters.Select(x => JsonConvert.SerializeObject(x)).ToArray();
        }

        private object[] Arguments
        {
            get
            {
                return this.func.Method.GetParameters()
                    .Select((p, i) => JsonConvert.DeserializeObject(this.jsonParameters[i], p.ParameterType))
                    .ToArray();
            }
        }

        public TResult Invoke()
        {
            return (TResult)this.func.GetType().GetMethod("Invoke").Invoke(this.func, this.Arguments);
        }
    }
}