# CleanArchitectureWebAPI_Rectangle

1. Launch Postman and Select Environment:
Start Postman and load the "rectangle_app" collection. Make sure to select the "rectangle_env" environment to ensure that you're using the correct environment variables.

2. Send "GetUsers" Request:
In the Postman sidebar, locate the "GetUsers" request within the "rectangle_app" collection.
Click the "Send" button to execute the request. This request will return three randomly generated users with different roles.
Review the response to see the details of the generated users.

3. Choose a User and Log In:
From the list of generated users, select one to log in.
In the Postman sidebar, locate the "Login" request within the "rectangle_app" collection.
Send the "Login" request with the chosen user's login and password information. This request will authenticate you as the selected user.

4. Copy Access Token from "Login" Response to "rectangle_env" Environment:
In the "Login" request response, locate the access token that is returned as part of the authentication process.
Select and copy the access token.
In Postman, go to the "rectangle_env" environment variables.
Locate the "token" variable in the environment and paste the copied access token as the new value.
Click the "Save" button to update the environment variable with the access token.

5. Send "FindRectangles" Request:
In the Postman sidebar, locate the "FindRectangles" request within the "rectangle_app" collection.
Configure the "FindRectangles" request with the specified coordinates in the request body.
Click the "Send" button to execute the "FindRectangles" request with the provided coordinates.
Review the response to see the list of rectangles that contain the specified coordinates.
