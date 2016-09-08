import java.util.Calendar;
import java.util.Random;

public class Tesing {

	public Tesing() {
		// TODO Auto-generated constructor stub
	}
	
	public static void main(String[]args){
		int i=5;
		Integer a=new Integer(5);
		System.out.println(a.getClass());
		
		int rnd;
		Random r=new Random();
		System.out.println(r.nextInt(1000)+1);
		
		
		Calendar c=Calendar.getInstance();
		System.out.println(c.get(Calendar.YEAR)+"년");
		System.out.println(c.get(Calendar.MONTH)+1+"월");
		System.out.println(c.get(Calendar.DATE)-1+"일");
		
		String s=new String("asd");
	}
	

}
