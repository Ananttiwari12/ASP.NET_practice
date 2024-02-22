namespace ASP.NET_tut.Models
{
    public static class CollegeRepository
    {
        public static List<Student> Students{get;set;} = [
                new() {
                    Id=1,
                    Name="Anant",
                    Email="anant0102@gmail.com",
                    Address="katni",
                },
                new (){
                    Id=2,
                    Name="Aman",
                    Email="aman0102@gmail.com",
                    Address="Bhopal",
                }
            ];
    }
}