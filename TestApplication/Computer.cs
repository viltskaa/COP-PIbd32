namespace TestApplication
{
    public class Computer
    {
        public int Id { get; set; }
        public string CPU { get; set; } = string.Empty;
        public string GPU { get; set; } = string.Empty;
        public int? RAM { get; set; }

        public Computer(int id, string cPU, string gPU, int rAM)
        {
            Id = id;
            CPU = cPU;
            GPU = gPU;
            RAM = rAM;
        }

        public Computer() {}
    }
}
