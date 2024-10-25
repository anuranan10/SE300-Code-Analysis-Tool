/*********************************************************
* Filename: Lab01_Kelley.java
* Author: Tatum Kelley
* Created: 1/16/2024
* Modified: 
*
* Purpose: Java Basics
*
* Attributes: 
*
* Methods: 
+main(String[]): void
*
*********************************************************/
import java.util.Scanner;

public class Lab01_Kelley {

	public static void main(String[] args) {
		int a = 2;
		int b = 4;
		int c = 6;
		int d = 8;
		
		String smile = "Happy!";
		String frown = "Sad!";
		String scowl = "Angry!";
		String what = "Confused!";
		
		boolean hi = true;
		boolean bye = false;
		boolean yes = (a < c);
		boolean no = (d < b);
			
		
		for (int i = 0; i <= c; i++) {
			System.out.println(i);
		}
		
		System.out.println("\n");
		
		while (d < 100){
			System.out.println(d);
			d = (d * 2);
			
		}
		
		System.out.println("\n");

		Scanner scan = new Scanner(System.in);
		System.out.println("Enter an integer!");
		int x = scan.nextInt();
		System.out.println("You entered " + x + "!\n");
		
		
		if (x <= 0) {
			System.out.println("Value is less than or equal to 0");
		} else if ((x > 50) && (x < 100)) {
			System.out.println("Value is between 50 and 100");
		} else if (x >= 100) {
			System.out.println("Value is greater than or equal to 100");
		} else if (x != 50) {
			System.out.println("Value does not equal 50");
		} else if ((x % 2) == 0) {
			System.out.println("Value is a multiple of 2");
		} else {
			System.out.println("Value is an odd number between 0 and 50");
		}
		

		
	}

}
