#include <iostream>
#include <string>

using namespace std;

int n;
void set();

namespace chokije {
    int n;
    void set();
}

namespace miriamme {
    int n;
    void set();
    namespace mir {
        int age;
        void setAge();
    }
}

int main() {
    ::set();
    chokije::set();
    miriamme::set();
    miriamme::mir::setAge();

    cout << "::n=" << ::n << endl;
    cout << "chokije::n=" << chokije::n << endl;
    cout << "miriamme::n=" << miriamme::n << endl;
    cout << "miriamme::mir::age=" << miriamme::mir::age << endl;
}

void set() {
    n = 10;
}

void chokije::set() {
    n = 20;
}

void miriamme::set() {
    n = 30;
}

void miriamme::mir::setAge(){
    age = 18;
}