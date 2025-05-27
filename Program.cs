using System.Runtime.InteropServices.Marshalling;

namespace volkov_gestion_image
{
    internal class Program
    {
        static void Main(string[] args)
        {
            customio.IO.Print("hello world");

            // always keep this in the end so that the shell properly continues after this runs
            customio.IO.Print("\n");
        }
    }
}
