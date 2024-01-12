namespace SV20T1080051.Web.Models
{
    public class PersonDAL
    {
        public List<Person> List()
        {
            List<Person> list = new List<Person>();

            list.Add(new Person()
            {
                PersonId = 1, 
                Name ="Chis Doan", 
                LivePlace ="77 Nguyễn Huệ",
                Email ="ChisDoan@gmail.com"
            });

            list.Add(new Person()
            {
                PersonId = 2,
                Name = "Lok Nguyen",
                LivePlace = "77 Nguyễn Huệ",
                Email = "LokNguyen@gmail.com"
            });

            list.Add(new Person()
            {
                PersonId = 3,
                Name = "Chung Buoi",
                LivePlace = "77 Nguyễn Huệ",
                Email = "ChungBuoi@gmail.com"
            });

            return list;
        }
    }
}
