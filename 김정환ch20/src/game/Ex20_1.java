package game;
import java.util.Random;
import java.util.Scanner;

class Die{
	private int nowface;
	Random r=new Random(System.nanoTime());
	
	public Die(){
		nowface=1;	
	}
	
	int roll(){
		nowface=r.nextInt(6)+1;
		return nowface;
	}
	
	void setValue(int v){
		if(v<7&&v>0){
			nowface=v;
			System.out.println("선택한 주사위 면은 "+nowface+"입니다.");
		}
		else{
			System.out.println("잘못된 입력입니다.");
		}
	}
	
	int getValue(){
		return nowface;
	}
	
	public String toString(){	
		return Integer.toString(nowface);
	}
}

public class Ex20_1 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int u=0,a=0;
		Die you=new Die();
		Scanner s=new Scanner(System.in);
		System.out.print("주사위 면을 고르세요(1~6 사이만 입력하시길 바랍니다.) : ");
		u=s.nextInt();
		you.setValue(u);
		a=you.getValue();
		
		int c=0;
		Die com=new Die();
		c=com.roll();
		
		if(a==c){
			System.out.println("맞췄습니다.\n컴퓨터가 선택한 면은"+com.toString()+"입니다.");
			
		}
		else{
			System.out.println("틀렸습니다.\n컴퓨터가 선택한 면은"+com.toString()+"입니다.");
		}
	}
}
