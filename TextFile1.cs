

public class FizzBuzz
{
    static void Main(string[] args)
    {
        String filePath = args[1];
        int[][] fileData; //firstDivisor, secondDivisor, countUpTo, for each line of file
        if(checkFileOK(filePath)){
		    fileData = parseFile(filePath);
			fizzBuzz(fileData);
		}
		return;
    }

    private bool checkFileOK(String filePath) {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File doesn't exist! Program Exiting...");
            return false;
        }
        return true;
    }


    private int[] parseFile(String filePath)
    {
        int[][] fileData;
        string[] lines = System.IO.File.ReadAllLines(filePath);

		foreach(String line in lines){
			string[] tokens = str.Split(' ');
			//parse first divisor
			fileData[i][0] = tokens[0];
			//parse second divisor
			fileData[i][1] = tokens[1];
			//parse number to count up to
			fileData[i][2] = tokens[2];

		}
        return fileData;
    }

    private void fizzBuzz(int[][] fileInput)
    {
        int divisor1;
        int divisor2;
        int value;

        for (int i = 0; i < fileInput.Length; i++ )
        {
            div1 = fileInput[i][0];
            div2 = fileInput[i][1];
            value = fileInput[i][2];

            Console.WriteLine(div1.ToString + " " + div2.ToString + " ");

            if (value % div1 == 0 && value % div2 == 0)
            {
                Console.WriteLine("FB");
            }
            else if (value % div1 == 0)
            {
                Console.WriteLine("F");
            }
            else if (value % div2 == 0)
            {
                Console.WriteLine("B");
            }
            else
            {
                Console.WriteLine(value.ToString);
            }
        }


    }

}