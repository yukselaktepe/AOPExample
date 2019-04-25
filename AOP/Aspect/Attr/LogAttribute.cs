using AOP.Aspect.Interface;
using Logger;
using System;
using System.Text;
using Newtonsoft.Json;

namespace AOP.Aspect.Attr
{
    public class LogAttribute : AspectBase, IBeforeVoidAspect, IAfterVoidAspect
    {
        ILogger _logger = new TextLogger();
        public void OnBefore()
        {
            StringBuilder sbLogMessage = new StringBuilder();
            sbLogMessage.AppendLine(string.Format("Method Name: {0}", AspectContext.Instance.MethodName));
            sbLogMessage.AppendLine(string.Format("Arguments: {0}", string.Join(",", AspectContext.Instance.Arguments)));
            _logger.Log(AspectContext.Instance.MethodName + "_Before_Log", sbLogMessage.ToString());
        }

        public void OnAfter(object value)
        {
            _logger.Log(AspectContext.Instance.MethodName + "_After_Log", JsonConvert.SerializeObject(value));

        }
    }
}
