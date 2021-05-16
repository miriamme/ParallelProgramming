#include <iostream>
using namespace std;

template <typename T>
class Data
{
private:
	T data_;
public:
	Data(T dt);
	T get_data();
};

int main(void)
{
	Data<string> str_data("C++ 수업");
	Data<int> int_data(12);
	
	cout << "str_data : " << str_data.get_data() << endl;	
	cout << "int_data : " << int_data.get_data() << endl;
	return 0;
}

template <typename T>
Data<T>::Data(T dt)
{
	data_ = dt;
}

template <typename T>
T Data<T>::get_data()
{
	return data_;
}