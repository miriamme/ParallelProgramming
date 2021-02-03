#include "Windows.h"
#include <stdio.h>
#include <tchar.h>
 
using namespace std;
 
int main(void) {
    _TCHAR str[] = "안녕하세요2019";    
    _tprintf("%s\n", str);
    _tprintf("%d\n", sizeof(str));
    system("pause");
    return 0;
}