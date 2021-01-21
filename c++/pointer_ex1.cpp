#include <iostream>
#include <string>

using namespace std;

int main(){
    int a = 10;
    cout << "a = " << a << endl;

    int* pa = &a;
    cout << "*pa = " << *pa << endl;
    cout << "pa = " << pa << endl;

    *pa = 20;
    cout << "a = " << a << endl;
}