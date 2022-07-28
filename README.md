# StorePrototype

## What is it

This is a simple mockup of a store front written in .NET 6 as a blazor app. It simulates a simple store experience . It has the store which displays items that can be bought. Allows logins using just a name to keep it simple. Allows purchase using an account that hold funds. Saves receipts that can be viewed by the user.

## Download

### Clone the git repository

`git clone https://github.com/ShaneButtCodeNL/StorePrototype.git`

### Run a test server

`dotnet watch`

## How to Use

### 1. Create a username.

Enter a username in the labeled input and it will create a user that can add items to a cart and look at reciepts of proir puchases made by that user.

### 2. Add Items to your cart.

There are several premade items to peruse at first, but you can use the debug menu to add more of randow quantities and prices. If you are not logged in you cannot add items to your cart.

### 3. Go to your cart.

Here you can remove a quantity of items from the cart, remove all of an item from the cart, select a shipping method and proceed to confirm payment method. If you are not logged in it will say to log in, if your cart is empty it will ask you to buy something (funny).

### 4. Confirm payment

Here you will enter in an account name and account number. There is a default account created called **Account0** with an account number of **0**. It has funds of 1234.56. In the debug menu you can see all available accounts, add funds to an existing account, and can also create new accounts. After enterin valid account info it will ask you to confirm the purchase or forget the account. If you have enough available funds the _Confirm purchase_ button will take you to a page containing the recipt of the order. If you have insuffcient funds the page will do nothing.

### 5. View past puchases

You can click on the _Reciepts_ Icon to see all past purchases. This will display a list of some distigushing values such as date and total so you can tell the apart. You can click on an item to bring up a more detailed reciept.

Have Fun
