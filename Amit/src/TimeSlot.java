import java.util.Arrays;
import org.apache.commons.lang.ArrayUtils;

public class TimeSlot {
	public static void main(String arg[]) {
		double timeSlot[][] = { { 8.0, 10.0 }, { 10.20, 10.40 }, { 10.40, 1.0 }, { 3.0, 4.0 }, { 3.30, 5.0 } };

		double tmepTime[][];

		int index = 0;
		do {
			int tt = index;
			do {
				if (timeSlot[index][1] >= timeSlot[index + 1][0]) {
					double temp = timeSlot[index + 1][1];
					timeSlot[index][1] = temp;
					timeSlot = (double[][]) ArrayUtils.remove(timeSlot, (index + 1));
				}
				tt++;

			} while (tt <= timeSlot.length - 1);
			index++;
		} while (index < timeSlot.length);

		for (int i = 0; i < timeSlot.length; i++) {
			for (int j = 0; j < 2; j++) {
				if (j != 0) {
					System.out.println(" to ");
				}
				System.out.println(timeSlot[i][j]);

			}

		}
	}
}
