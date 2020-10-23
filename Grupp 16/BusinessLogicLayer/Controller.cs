using DataAccesLayer.Repositories;
using Models;

namespace BusinessLogicLayer
{
    public class Controller
    {
        private IRepository<Podcast> podcastRepository;

        public Controller()
        {
            podcastRepository = new PcRepository();
        }

        public void CreatePodcast(string name, string pn, string address, string objectType)
        {
            Person newPerson = null;
            if (objectType.Equals("Student"))
            {
                newPerson = new Student(name, pn, address);
            }
            if (objectType.Equals("Employee"))
            {
                newPerson = new Employee(name, pn, address);
            }
            personRepository.Create(newPerson);
        }
    }
}
