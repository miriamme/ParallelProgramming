/*
	PartAdder.cpp
	프로그램 설명 : 전달된 인자 사이의 수 덧셈.
*/

#include <stdio.h>
#include <windows.h>
#include <tchar.h>

int _tmain(int argc, TCHAR *argv[])
{
	if (argc != 3)
		return -1;

	DWORD start = _ttoi(argv[1]);
	DWORD end = _ttoi(argv[2]);
	DWORD total = 0;

	for (DWORD i = start; i <= end; i++)
	{
		_tprintf(_T("%d + %d = "), total, i);
		total += i;
		_tprintf(_T("%d\n"), total);
	}

	return total;
}
