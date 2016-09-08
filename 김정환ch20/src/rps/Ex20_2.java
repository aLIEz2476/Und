package rps;

import java.util.Random;
import java.util.Scanner;

class SRP{
	private int user=3, flag=0, com;
	public SRP(){
		selectRoot(user);
		for(;;){
			RandomMaker();
			show();
			battle();				
			if(flag==10)
				break;
		}
	}
	
	public void battle(){
	
		if(com==user){
			System.out.println("비겼습니다. 재대결에 들어갑니다.");
			RandomMaker();
			selectRoot(user);
			flag=5;
		}
		else if((com==0&&user==2)||(com==1&&user==0)||(com==2&&user==1)){
			System.out.println("컴퓨터가 이겼습니다.");
			flag=10;
		}
		else if(!(com==0&&user==2)||!(com==1&&user==0)||!(com==2&&user==1)){
			System.out.println("컴퓨터가 졌습니다.");
			flag=10;
		}
		
	}
	
	public void show(){
		if(com==0)
			System.out.println("컴퓨터는 가위를 선택합니다.");
		else if(com==1)
			System.out.println("컴퓨터는 바위를 선택합니다.");
		else if(com==2)
			System.out.println("컴퓨터는 보자기를 선택합니다.");
	}
	
	void selectRoot(int u){
		System.out.print("하나를 선택하시오 : 가위(0), 바위(1), 보(2) : ");
		Scanner s=new Scanner(System.in);
		u=s.nextInt();
		if(u>=0&&u<3){
			user=u;
		}
		else{
			System.out.println("다시 선택하시길 바랍니다.");
			System.exit(user);
		}
	}
	
	void RandomMaker(){
		Random r=new Random(System.nanoTime());
		com=r.nextInt(2);
		
	}
}


public class Ex20_2 {

	public static void main(String[] args) {
		SRP g=new SRP();
	}

}
