using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CBA.BusinessLogic
{
	public class UtilityLogic
	{
		public void SendMail(string from, string to, string subject, string body)
		{
			var message = new MailMessage();
			message.To.Add(new MailAddress(to));
			message.From = new MailAddress(from);
			message.Subject = subject;
			message.Body = body;
			message.IsBodyHtml = true;

			using (var smtp = new SmtpClient())
			{
				var credential = new NetworkCredential
				{
					UserName = ConfigurationManager.AppSettings["mailAccount"],
					Password = ConfigurationManager.AppSettings["mailPassword"]
				};
				smtp.Credentials = credential;
				smtp.Host = "smtp.gmail.com";
				smtp.Port = 587;
				smtp.EnableSsl = true;
				smtp.Send(message);
			}
		}

		public string GetRandomPassword()
		{
			Random rand = new Random();
			int N = rand.Next(6, 10);   //6 to 10 characters of password
			char[] passwordChar = new char[N];
			int uppercaseAlphabetCount = N - 5;
			int lowercaseAlphabetCount = 1;
			int numberCount = 2; 
			int symbolCount = 2;

			char[] lowercaseAlphabets = new char[]
			{
				'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',};
			char[] uppercaseAlphabets = new char[] 
			{ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', };
			char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
			char[] specialCharacters = new char[] { '.', ',', ';', '/', '!', '@', '#', '$', '%', '^', '&', '*', '|' };

			//getting the lowercase alphabets
			for (int i = 0; i < lowercaseAlphabetCount; i++)
			{
				int index = rand.Next(0, lowercaseAlphabets.Count() - 1);
				var myChar = lowercaseAlphabets[index];
				passwordChar[i] = myChar;
			}

			//getting the uppercase alphabets
			int charPosition = lowercaseAlphabetCount;
			for (int i = 0; i < uppercaseAlphabetCount; i++)
			{
				int index = rand.Next(0, uppercaseAlphabets.Count() - 1);
				var myChar = uppercaseAlphabets[index];
				passwordChar[charPosition] = myChar;
				charPosition++;
			}

			//getting the numbers
			charPosition = uppercaseAlphabetCount + lowercaseAlphabetCount;
			for (int i = 0; i < numberCount; i++)
			{
				int index = rand.Next(0, numbers.Count() - 1);
				var n = numbers[index];
				passwordChar[charPosition] = n;
				charPosition++;
			}

			//getting the special characters
			charPosition = uppercaseAlphabetCount + lowercaseAlphabetCount + numberCount;
			for (int i = 0; i < symbolCount; i++)
			{
				int index = rand.Next(0, specialCharacters.Count() - 1);
				var symb = specialCharacters[index];
				passwordChar[charPosition] = symb;
				charPosition++;
			}

			string password = new string(passwordChar);
			return password;
		}
		/*public string GetRandomPassword()
		{
			Random random = new Random();
			int N = random.Next(7, 13);   // 7 to 13 characters of password
			char[] passwordCharacters = new char[N];
			int alphabetCount = N - 5;
			int numberCount = 3;
			int symbolCount = 2;

			char[] alphabets = new char[]
			{
				'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
			};
			char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
			char[] specialSymbols = new char[] { '.', ',', ';', '/', '!', '#', '&', '%', '$', '@', '*', '|' };

			// Generate Alphabets
			for (int i = 0; i <= alphabetCount - 1; i++)
			{
				int index = random.Next(0, alphabets.Count() - 1);
				var selectedAlphabet = alphabets[index];
				// Randomize the Case
				int toLower = random.Next(0, 1);
				if (toLower == 1)
					selectedAlphabet = selectedAlphabet.ToString().ToLower()[0];
				else
					selectedAlphabet = selectedAlphabet.ToString().ToUpper()[0];

				passwordCharacters[i] = selectedAlphabet;
			}

			// Generate numbers
			int characterPosition = alphabetCount;		// Represents the next availble index after the generated alphabets 
			for (int i = 0; i <= numberCount - 1; i++)
			{
				int index = random.Next(0, numbers.Count() - 1);
				var selectedNumber = numbers[index];
				passwordCharacters[characterPosition] = selectedNumber;
				characterPosition++;
			}

			// Generate symbols
			characterPosition = alphabetCount + numberCount;      // Next availble index after the generated alphabets and numbers
			for (int i = 0; i <= symbolCount - 1; i++)
			{
				int index = random.Next(0, specialSymbols.Count() - 1);
				var selectedSymbol = specialSymbols[index];
				passwordCharacters[characterPosition] = selectedSymbol;
				characterPosition++;
			}

			string password = new string(passwordCharacters);
			return password;
		}*/
	}
}