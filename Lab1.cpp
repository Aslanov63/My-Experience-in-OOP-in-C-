#include <iostream>
#include <string>
#include <algorithm>
#include <fstream>
#include <vector>
using namespace std;







void printQuotes(const vector<string>& quotes) {

for(const auto& q : quotes){
cout << q << endl;
}
}



void brickSort(vector<string>& quotes) {
bool sorting_status = false;
int n = quotes.size();
int step = 1;

cout<<"Swap number:"<< step++<<endl;

while(!sorting_status){
for (int i =0 ; i <=n-1 ; i+=2) {
    if(quotes[i]> quotes [i+1]){
        cout<<"Swapping: " << quotes[i] << " and " << quotes[i+1]<<"....." <<endl;
        swap(quotes[i], quotes[i+1]);
        sorting_status = false;
        
    }
for(int i=1; i< n-1; i+=2){
    if(quotes[i]> quotes [i+1]){
        cout<<"Swapping: " << quotes[i] << " and " << quotes[i+1]<<"....." <<endl;
        swap(quotes[i], quotes[i+1]);
        sorting_status = false;
        
    }


}


}
    



}
void countingSort(vector<string>& quotes) {
 
 
 
    // пока пусто
}
void quickSort(vector<string>& quotes) {




    // пока пусто
}
void insertionSort(vector<string>& quotes) {




    // пока пусто
}





int main(){

    const string path_to_program ="quotes.data";
    ifstream file(path_to_program);
    if(!file.is_open()){
        cout << "Wrong path or file does not exist." << endl;
        return 0;

    }
    vector <string> quotes;
    string line;
    while(getline (file,line)){
        quotes.push_back(line);


    }
    file.close();

    cout <<"MENU" <<endl;
    cout <<"1. Display all quotes" <<endl;
    cout <<"2. Brick Sort" <<endl;
    cout <<"3. Counting sort" <<endl;
    cout <<"4. Quick-sort(TURBO)" <<endl;
    cout <<"5. Insertion sort(SLOW) " <<endl;
    cout <<"6. Exit" <<endl;
    int choice;
    cout <<"Enter your choice: ";
    cin >> choice;
    system("clear");

    switch(choice){
        case 1:
            printQuotes(quotes);
            break;
        case 2:
            brickSort(quotes);
            break;
        case 3: 
            countingSort(quotes);
            break;  
        case 4:
            quickSort(quotes);
            break;
        case 5:
            insertionSort(quotes);
            break;
        case 6:
            cout <<"Exiting program." <<endl;
            break;
        default:
            cout <<"Invalid choice. Please try again." <<endl;
            break;

    }
    


}
    
    
      




