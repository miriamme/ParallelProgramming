class Smartphone:
    """
    Smartphone class
    """
    def __init__(self, brand, details):
        self._brand = brand
        self._details = details
    
    def __str__(self):
        return f'str : {self._brand} - {self._details}'

    def __repr__(self):
        return f'repr : {self._brand} - {self._details}'

Smartphone1 = Smartphone('Iphone', {'color' : 'White', 'price': 10000})
Smartphone2 = Smartphone('Galaxy', {'color' : 'Black', 'price': 8000})
Smartphone3 = Smartphone('Blackberry', {'color' : 'Silver', 'price': 6000})

print(Smartphone1)
print(Smartphone1.__dict__)
print(Smartphone2.__dict__)
print(Smartphone3.__dict__)