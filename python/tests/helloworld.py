class Person:
    def __init__(self, firstName, secondName):
        self.FirstName = firstName
        self.SecondName = secondName
        self.Age = 0
    def SetFirstName(self, firstName):
        self.FirstName = firstName
    def SetSecondName(self, secondName):
        self.SecondName = secondName
    def toString(self):
        return self.FirstName+" "+self.SecondName

person = Person("cho","kije")
print(person.toString())

person.SetFirstName("hong")
person.SetSecondName("kildong")
print(person.toString())