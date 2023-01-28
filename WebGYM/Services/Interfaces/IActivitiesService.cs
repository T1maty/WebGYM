using WebGYM.Models;

namespace WebGYM.Services.Interfaces
{
    public interface IActivitiesService
    {
        public Activities AddActivities(Activities activities);

        public Activities GetActivities(Activities activities);
    }
}
