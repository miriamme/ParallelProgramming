#include <iostream>

int main() {
    std::string message = "Hello world";
    std::wstring wmessage;

    wmessage.assign(message.begin(), message.end());
    wprintf(wmessage.c_str());

    return 0;
}
