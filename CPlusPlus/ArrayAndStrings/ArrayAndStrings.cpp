#include <iostream>
#include <unordered_set>
#include "ArrayAndStrings.h"

using namespace std;

int main()
{
	Run();
	return 0;
}

void Run()
{
	cout << "Showing the results for IsUnique.cpp (1.1)" << endl;
	cout << IsUnique("abc") << endl;
}

bool IsUnique(string word)
{
	const char* letters = word.c_str();
	int word_length = strlen(letters);
	unordered_set<char> letters_set;

	for (int i = 0; i < word_length; i++)
	{
		letters_set.insert(letters[i]);
	}

	return letters_set.size() == word_length;
}
