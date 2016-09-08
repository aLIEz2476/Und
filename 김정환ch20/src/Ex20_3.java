import java.util.Arrays;
import java.util.Scanner;
import java.util.StringTokenizer;

public class Ex20_3 {
	
	public static void main(String[] args) {
		String s;
		
		System.out.print("문자열을 입력하시오 : ");
		Scanner scan=new Scanner(System.in);
		s=scan.nextLine();
		StringTokenizer tk = new StringTokenizer(s);
		int cnt=tk.countTokens();
		String []sa=new String[cnt];
		int i=0;
		while(tk.hasMoreTokens()){
			sa[i]=tk.nextToken();
			System.out.println(sa[i]);
			i++;
			
		}
		System.out.println("모두 "+cnt+"개의 단어가 있습니다.");	
		Arrays.sort(sa);
		for(int j=0;j<cnt;j++){
			System.out.println(sa[j]);
		}

	}
}
