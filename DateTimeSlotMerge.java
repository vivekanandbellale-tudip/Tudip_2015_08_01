import java.io.Console;
import java.util.Iterator;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;
import java.util.TreeMap;

public class DateTimeSlotMerge 
{
	private TreeMap<String,String> slotFrom;//Tree Map Variable to store time slot_1
	private TreeMap<String,String> slotTo;//Tree map Variable to store time slot_2
	private Console inputReciever;//Scanner class to take input.
	private String currFrm,currTo,campmFrm,campmTo;
	public DateTimeSlotMerge() {
		// TODO Auto-generated constructor stub
		slotFrom=new TreeMap<String,String>();//Map one initialize
		slotTo=new TreeMap<String,String>();//Map two initialize
		inputReciever=System.console();
		
	}
	void getSlots()
	{
		slotFrom.put(currFrm=inputReciever.readLine("From (eg. 10.00):"),campmFrm=inputReciever.readLine("AM/PM:"));
		slotTo.put(currTo=inputReciever.readLine("TO (eg. 11.00):"),campmTo=inputReciever.readLine("AM/PM:"));
		mergeSlots(currFrm,campmFrm,currTo,campmTo);
	}
	void mergeSlots(String currFrm,String campmfrm, String currTo,String campmto)
	{
		if((!slotFrom.isEmpty()) && (!slotTo.isEmpty()))
		{
			
			//If slot 1 end and current slot start are same.
			if((slotTo.containsKey(currFrm)) && (slotTo.containsValue(campmfrm)))
			{
				slotTo.remove(currFrm);
				slotTo.put(currTo, campmto);
			}
			//If slot 2 is in between or more than currrent
			//Setting Iterator to move through slot one.
			Set<Map.Entry<String, String>> slotfrm = slotFrom.entrySet();
			Iterator<Entry<String, String>> slotfrmIterator = slotfrm.iterator();
			
			//Setting Iterator to move through slot two.
			Set<Map.Entry<String, String>> slotto = slotTo.entrySet();
			Iterator<Entry<String, String>> slottoIterator = slotto.iterator();
			String removenow="";
			while(slotfrmIterator.hasNext() && slottoIterator.hasNext())
			{
				Entry<String,String> sl1=slotfrmIterator.next();
				Entry<String,String> sl2=slottoIterator.next();
				if(Float.parseFloat(currFrm)>Float.parseFloat(sl1.getKey()) && Float.parseFloat(currFrm)<Float.parseFloat(sl2.getKey()) && Float.parseFloat(currTo) > Float.parseFloat(sl2.getKey()))
				{
				   removenow=sl2.getKey();
				   break;
				}
			}
			slotTo.remove(removenow);
			slotTo.put(currTo, campmto);
			
		}
		
	}
	void displaySlots()
	{
		/*Setting Iterator to move through slot one.*/
		Set<Map.Entry<String, String>> slotfrm = slotFrom.entrySet();
		Iterator<Entry<String, String>> slotfrmIterator = slotfrm.iterator();
		
		/*Setting Iterator to move through slot two.*/
		Set<Map.Entry<String, String>> slotto = slotTo.entrySet();
		Iterator<Entry<String, String>> slottoIterator = slotto.iterator();
		
		System.out.println("\nMerged and Sorted Slots are,\n");
		while(slotfrmIterator.hasNext() && slottoIterator.hasNext())
		{
			Entry<String,String> sl1=slotfrmIterator.next();
			Entry<String,String> sl2=slottoIterator.next();
			System.out.println("From :" +sl1.getKey()+" "+sl1.getValue()+" TO:"+sl2.getKey()+" "+sl2.getValue());
		}
	}
	public static void main(String args[])
	{
		DateTimeSlotMerge slotM=new DateTimeSlotMerge();
		slotM.getSlots();
		slotM.getSlots();
		slotM.getSlots();
		slotM.displaySlots();
	}
}
