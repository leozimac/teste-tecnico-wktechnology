using System.Text;

namespace Products.API.Domain.Utils
{
    public static class ExceptionUtil
    {
        public static string GetAllMessages(this Exception ex)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append(ex.Message);

            Exception inner = ex.InnerException;
            int indexInner = 1;

            while (inner != null)
            {
                msg.Append($" | Inner{indexInner}: {inner.Message}");
                inner = inner.InnerException;
            }
            
            return msg.ToString();
        }
    }
}
