#include <iostream>
#include <string>
#include <algorithm>
#include <fstream>
#include <vector>
using namespace std;

void printQuotes(const vector<string>& quotes) {
    for(const auto& q : quotes) {
        cout << q << endl;
    }
}

void brickSort(vector<string>& quotes) {
    bool sorted = false;
    int n = quotes.size();

    while (!sorted) {
        sorted = true;

        for (int i = 0; i < n-1; i += 2) {
            if (quotes[i] > quotes[i+1]) {
                cout << "Swapping: " << quotes[i] << " and " << quotes[i+1] << endl;
                swap(quotes[i], quotes[i+1]);
                sorted = false;
            }
        }

        for (int i = 1; i < n-1; i += 2) {
            if (quotes[i] > quotes[i+1]) {
                cout << "Swapping: " << quotes[i] << " and " << quotes[i+1] << endl;
                swap(quotes[i], quotes[i+1]);
                sorted = false;
            }
        }
    }
    printQuotes(quotes);
}

void countingSort1(vector<string>& quotes) {
    vector<vector<string>> count(26); //alpabet

    for (const auto& q : quotes) {
        if (!q.empty()) {
            char first = tolower(q[0]);
            if (first >= 'a' && first <= 'z') {
                count[first - 'a'].push_back(q);
            }
        }
    }

    for (int i = 0; i < 26; ++i) {
        if (!count[i].empty()) {
            cout << "[" << char('A' + i) << "] (" << count[i].size() << "):" << endl;
            for (const auto& q : count[i]) {
                cout << q << endl;
            }
            cout << endl;
        }
    }
}

void countingSort2(vector<string>& quotes) {
    size_t max_len = 0;
    for (const auto& q : quotes) { ///find the longest word
        if (q.length() > max_len) {
            max_len = q.length();
        }
    }

    vector<vector<string>> buckets(max_len+1);

    for (const auto& q : quotes) {
        buckets[q.size()].push_back(q);
    }
    quotes.clear();

    for (size_t i = 0; i < buckets.size(); ++i) {
        if (!buckets[i].empty()) {
            for (const auto& q : buckets[i]) {
                quotes.push_back(q);
             
            }
           
        }
    }
    printQuotes(quotes);

}

void quickSortHelper(vector<string>& quotes, int left, int right) {
    if (left >= right) return; 
    int i = left, j = right;
    string pivot = quotes[left + (right - left) / 2]; 

    while (i <= j) { 
        while (quotes[i] < pivot) i++;
        while (quotes[j] > pivot) j--; 
        if (i <= j) {
            swap(quotes[i], quotes[j]); 
            i++; 
            j--; 
        }
    }

    quickSortHelper(quotes, left, j); 
    quickSortHelper(quotes, i, right); 
}

void quickSort(vector<string>& quotes) {
    quickSortHelper(quotes, 0, quotes.size() - 1); 
    printQuotes(quotes); 
}

void insertionSort(vector<string>& quotes) {
    for (size_t i = 1; i < quotes.size(); ++i) {
        string key = quotes[i];
        int j = i - 1;
        while (j >= 0 && quotes[j] > key) {
            quotes[j + 1] = quotes[j];
            j--;
        }
        quotes[j + 1] = key;
    }
    printQuotes(quotes);
}

int main() {
    const string path_to_program = "quotes.data";
    ifstream file(path_to_program);
    if (!file.is_open()) {
        cout << "Wrong path or file does not exist." << endl;
        return 0;
    }
    vector<string> quotes;
    string line;
    while (getline(file, line)) {
        quotes.push_back(line);
    }
    file.close();

    cout << "MENU" << endl;
    cout << "1. Display all quotes" << endl;
    cout << "2. Brick Sort" << endl;
    cout << "3. Counting sort by first letter" << endl;
    cout << "4. Quick-sort (TURBO)" << endl;
    cout << "5. Insertion sort (SLOW)" << endl;
    cout << "6. Counting sort by Length" << endl;
    cout << "7. Exit" << endl;
    int choice;
    cout << "Enter your choice: ";
    cin >> choice;
    system("clear");

    switch (choice) {
        case 1:
            printQuotes(quotes);
            break;
        case 2:
            brickSort(quotes);
            break;
        case 3:
            countingSort1(quotes);
            break;
        case 4:
            quickSort(quotes);
            break;
        case 5:
            insertionSort(quotes);
            break;
        case 6:
            countingSort2(quotes);
            break;
        case 7:
            cout << "Exiting program." << endl;
            break;
        default:
            cout << "Invalid choice. Please try again." << endl;
            break;
    }
}







