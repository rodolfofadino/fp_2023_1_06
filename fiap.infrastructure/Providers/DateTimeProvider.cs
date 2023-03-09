using fiap.application.Interfaces;

namespace fiap.infrastructure.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetNow()
        {
            return DateTime.Now;
        }
    }
}
