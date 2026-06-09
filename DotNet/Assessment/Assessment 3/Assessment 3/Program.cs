using System;
using System.IO;

namespace IPL
{
    //Program 1 - IPL
    class CricketTeam
    {
        public void Pointscalculation(int no_of_matches)
        {
            int sum = 0;
            int[] scores = new int[no_of_matches];
            Console.WriteLine("\nEnter the scores:");
            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write("Match " + (i + 1) + ": ");
                scores[i] = Convert.ToInt32(Console.ReadLine());
                sum += scores[i];
            }
            double average = (double)sum / no_of_matches;
            Console.WriteLine("\n--- IPL Score Details ---");
            Console.WriteLine("Total Matches: " + no_of_matches);
            Console.WriteLine("Sum of Scores: " + sum);
            Console.WriteLine("Average Score: " + average);
        }
    }

    //Program - Mobile Phone
    class MobilePhone
    {
        // Delegate
        public delegate void RingEventHandler();

        // Event
        public event RingEventHandler OnRing;
        public void ReceiveCall()
        {
            Console.WriteLine("\nIncoming Call...\n");
            OnRing?.Invoke();
        }
    }
    // Subscribers
    class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }
    class ScreenDisplay
    {
        public void ShowCaller()
        {
            Console.WriteLine("Displaying caller information...");
        }
    }
    class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }

    //Main Class
    class Program
    {
        static void Main(string[] args)
        {
            //Program 1
            CricketTeam team = new CricketTeam();
            Console.Write("Enter number of matches: ");
            int matches = Convert.ToInt32(Console.ReadLine());
            team.Pointscalculation(matches);


            //Program 2
            string filePath = "CSharp.txt";
            try
            {
                // Append mode
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    Console.WriteLine("\nEnter text to append to file:");
                    string text = Console.ReadLine();
                    writer.WriteLine(text);
                }
                Console.WriteLine("Text successfully written to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            //Program 3
            MobilePhone phone = new MobilePhone();
            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay screen = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();
            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += screen.ShowCaller;
            phone.OnRing += vibration.Vibrate;
            phone.ReceiveCall();
        }
    }
}


