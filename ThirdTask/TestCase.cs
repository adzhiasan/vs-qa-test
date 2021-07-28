using System;

namespace ThirdTask
{
    public class TestCase
    {
        public delegate void Prep();
        public delegate void Run();
        public delegate void CleanUp();

        public int tc_id { get; set; }
        public string Name { get; set; }
        public CleanUp clean_up { get; set; }
        public Prep prep { get; set; }
        public Run run { get; set; }
        public void execute()
        {
            try
            {
                Console.WriteLine("-----------------------------------\n" + "" +
                    $"Test {tc_id}: {Name}\n" + 
                    "-----------------------------------");
                Console.WriteLine("Starting execution...");
                if (prep != null)
                {
                    Console.WriteLine("Preparation in the process...");
                    prep();
                    Console.WriteLine("Preparation was sucessfull!");
                }

                if (run != null)
                {
                    Console.WriteLine("Running...");
                    run();
                    Console.WriteLine("Running was sucessfull!");
                }

                if (clean_up != null)
                {
                    Console.WriteLine("Cleaning up...");
                    clean_up();
                    Console.WriteLine("Cleaning up was sucessfull!");
                }
                Console.WriteLine("Execution completed sucessfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
