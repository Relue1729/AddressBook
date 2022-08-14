# AddressBook
Small application that stores a list of contacts and their phone numbers

Video-demonstration:

[<img src="https://raw.githubusercontent.com/Relue1729/AddressBook/main/Thumbnail.png" width="75%">](https://youtu.be/miyyIoixOwI "AddressBook Sample Project")

Phone number can be added in any format, as long as it starts with 7 or 8 and contains 11 digits, it's automatically converted to +7-xxx-xxx-xx-xx format.

The data is stored in XmlData/Contacts.xml. If this file is not present it would be created containing test data.

Requirements Specification:

You need to create an "Address book" application, which would have following features:

- List of contacts, including ID, Name and Phone number
- Ability to add a new contact
- Ability to delete contacts
- Ability to edit contacts
- Data is stored in xml format
- Data is validated (phone number should be in the +7-xxx-xxx-xx-xx format, name should be from 2 to 50 symbols long), field border should be highlited if the field has been filled incorrectly
- Application needs to have a custom style, which is described in a separate xaml file

* ID - contact identification number assigned by the application at the time of its creation.
