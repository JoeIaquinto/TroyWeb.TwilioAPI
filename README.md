# TroyWeb.TwilioAPI
Windows Workflow activities to send and receive SMS messages, MMS messages and fax documents via Twilio to enable phone communication for a UiPath robot

This activity package allows you to connect UiPath RPA processes to the Twilio API in order to send SMS and MMS messages. 

It is as simple as adding your Twilio account ID and Authorization Token, adding the Send Message activity and providing a Twilio phone number you have added to your account, and the phone number to send the message to. Add a message body or Media URL to add to the message, and the SMS is sent to the phone almost immediately after execution. 

Sending a Fax is also very simple. Add the Send Fax activity, enter your Twilio Fax-Enabled phone number to send the fax from, the fax number to send the document to and a publicly accessible URL to a PDF file. Optionally, set the Quality property for control of the quality of the sent fax. You are able to download sent and recieved faxes via the Download Fax activity, providing the FaxResource object retrieved from a Get Fax activity and a file path to save the faxed PDF.

* SMS/MMS
	* Send an SMS/MMS Message
	* Get Messages sent to/from Twilio
		* Filter by number sent to/from, date sent before/after
	* Get information for a specific message
	* Get MMS Message medi
	* Get information about Alpha Senders and Short Codes in the account

* Faxing
	* Send a Fax of a PDF available at a URL
	* Get faxes sent/ received from account
		* Filter by number sent to/from, date created before/after
	* Get information for a specific fax
	* Cancel a queued fax
	* Delete a fax and associated document
	* Download Fax document

* Phone Numbers
	* Get local, mobile, and toll-free phone numbers available for purchase
	* Look-up information about a phone number
		* Look-up caller id
		* Look-up carrier information
		* Use Twilio LookUp Add-Ons
	* Format Phone Number to E.164 International format
		* Parse a phone number with formatting
		* Validate that a phone number can exist 

* Get prices of using Twilio
* Manage Twilio Accounts
