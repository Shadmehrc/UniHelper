<!-- Project Name - .NET 7 API with CLEAN Architecture -->
<h1 align="center">.NET 7 simple API with CLEAN Architecture</h1>

<p align="center">
  This is a simple .NET 7 API project with a CLEAN architecture that comes with essential tools and configurations to kickstart your development. It includes features such as logging, JWT authorization, Swagger, CORS setup, a basic repository folder, and more.
</p>

<!-- Getting Started -->
<h2>Getting Started</h2>

<p>Follow the steps below to get a copy of the project up and running on your local machine for development and testing purposes.</p>

<h3>Prerequisites</h3>

<p>Make sure you have the following installed on your machine:</p>

<ul>
  <li><a href="https://dotnet.microsoft.com/download/dotnet/7.0">.NET 7 SDK</a></li>
  <li><a href="https://git-scm.com/">Git</a></li>
</ul>

<h3>Clone the Repository</h3>

<p>Clone this repository to your local machine using Git:</p>

<pre><code>git clone https://github.com/Alirale/SimpleAPI.git</code></pre>

<h3>Configuration</h3>

<p>Before running the project, you need to make some configurations:</p>

<ol>
  <li><strong>JWT Authorization:</strong> Update the JWT secret key and expiration in the <code>appsettings.json</code> file:</li>
</ol>

<pre><code>{
   "JWtConfig": {
    "key": "{#################################}",
    "issuer": "Alireza",
    "audience": "Peaple"
  },
}</code></pre>

<ol start="2">
  <li><strong>CORS Configuration:</strong> If needed, configure CORS settings in the <code>Startup.cs</code> file.</li>
</ol>

<h3>Running the Application</h3>

<p>To run the application, navigate to the project directory and execute the following command:</p>

<pre><code>dotnet run</code></pre>

<p>The API will be accessible at <a href="https://localhost:5001">https://localhost:5001</a> by default.</p>


<h3>API Documentation</h3>

<p>This project comes with Swagger enabled, making it easier to test and explore the API endpoints. Access the Swagger documentation by navigating to <a href="https://localhost:5001/swagger">http://localhost:5000/swagger/index.html</a> after running the application.</p>

</code></pre>


<hr>

<p align="center">Feel free to clone this repository and continue writing code to build your awesome .NET 7 API using the CLEAN architecture! If you have any questions or need further assistance, don't hesitate to ask.</p>

<p align="center">Happy coding! 🚀</p>
