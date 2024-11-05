/***********************************
 * Filename: Lab05_RandomRacer_Kelley
 * Author: Tatum Kelley
 * Collaborators:
 * Created: 02/13/2024
 * Modified:
 * Purpose: The class contains a name and distance for a Random racer. The distance
updates a random number from 0-11.
 *
 *
 * Attributes:
 * -name: String
 * -distance: double
 * -setValue: double
 *
 *
 * Methods:
 * +<<constructor>> Lab05_RandomRacer(String)
 * +moveRacer(): void
 * +toString(): String
 * +getName(): String
 * +getDistance(): double
 ***********************************/
import java.util.Random;

public class Lab05_ConstantRacer_Kelley {


	private String name;
	private double distance;
	private double setValue;
	
	public static void main(String[] args) {
		System.out.println("Testing constructor:");
		Lab05_ConstantRacer_Kelley cr1 = new Lab05_ConstantRacer_Kelley("Jeff");
		System.out.println(cr1.toString());
		
		System.out.println("Testing moveRacer");
		cr1.moveRacer();
		System.out.println(cr1.toString());
		
		System.out.println("Testing getters");
		System.out.println("Get name:" + cr1.getName() + " Get distance: " + cr1.getDistance());
	}
	
	public Lab05_ConstantRacer_Kelley (String racerName) {
		name = racerName;
		distance = 0.0;
		Random rand = new Random();
		setValue = rand.nextDouble(10) + 1;
	}
	public void moveRacer() {
		distance += setValue;
	}

	public String toString() {
		String racerString = "Name: " + name;
		racerString += "\nDistance: " + distance;
		return racerString;
	}
	public String getName() {
		return name;
	}
	public double getDistance() {
		return distance;
	}
}

