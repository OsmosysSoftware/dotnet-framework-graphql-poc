# Adding GraphQL to a .NET Framework 4.5.2 Project

This guide covers integrating GraphQL into a .NET Framework Project.

## Understanding GraphQL Components:

- **Query:** Retrieves data from the API.
- **Schema:** Defines the data structure and interactions.
- **Types:** Represent data objects and their characteristics.
- **Mutation:** Modifies data on the server.

## Implementation Steps:

1. **Choose a Library:**

   - This implementation uses `GraphQL` Nugget Package.

2. **Install the Package:**

   - Add GraphQL and other related packages to your project.
   - Used Package in this implementation
     ![Example Image](./images/package.png)

3. **Create GraphQL Schema:**

   - Define the schema.
   - Include queries, types, and potentially mutations.

4. **Integrate with Existing API (Optional):**

   - Reuse data models and business logic from your existing REST API.
   - Create resolvers to fetch data from your existing API or database.

5. **Expose GraphQL Endpoint:**

   - Configure your application to handle GraphQL requests.

6. **Test the GraphQL API:**
   - Use tools like Postman or GraphiQL to send requests and validate responses.

## Walkthrough:

### App_Start Configuration:

- Set up Ninject dependency injection framework.
- Register services, including the schema and resolvers in the `GraphQLConfig.cs`

  ```c#
  private static void RegisterServices(IKernel kernel)
  {
      kernel.Bind<ITaskRepository>().To<TaskRepository>();
      kernel.Bind<IDocumentExecuter>().To<DocumentExecuter>();
      kernel.Bind<TaskQuery>().ToSelf();
      kernel.Bind<TaskType>().ToSelf();
      kernel.Bind<TaskInputType>().ToSelf();
      kernel.Bind<ISchema>().To<GraphQLSchema>();

      // Pass the same kernel
      kernel.Bind<GraphQL.IDependencyResolver>().To<GraphQLDependencyResolver>().WithConstructorArgument(kernel);
  }
  ```

### Create a Controller:

- Defines a `Post` method that accepts a GraphQL query and executes it.

  ```c#
  public async Task<IHttpActionResult> Post([FromBody] GraphQLQuery query)
  {
      if (query == null)
      {
          throw new ArgumentNullException(nameof(query));
      }

      var inputs = query.Variables.ToInputs();
      var executionOptions = new ExecutionOptions
      {
          Schema = _schema,
          Query = query.Query,
          Inputs = inputs
      };

      var result = await _documentExecuter
          .ExecuteAsync(executionOptions);

      if (result.Errors?.Count > 0)
      {
          return BadRequest();
      }

      return Ok(result);
  }
  ```

### Create a GraphQL Model:

- Defines the structure of the expected GraphQL query object.
  ```c#
  public class GraphQLQuery
  {
      public string OperationName { get; set; }
      public string NamedQuery { get; set; }
      public string Query { get; set; }
      public JObject Variables { get; set; }
  }
  ```

### Dependency Resolver:

- Resolves dependencies for the GraphQL execution process.

  ```c#
  public T Resolve<T>()
  {
      return (T)Resolve(typeof(T));
  }

  public object Resolve(Type type)
  {
      return _kernel.Get(type);
  }
  ```

### Add Queries and Mutations (Optional):

- Define queries to retrieve data and mutations to modify data (in this example, only queries are shown).

  ```c#
  public TaskQuery(ITaskRepository taskRepository)
  {
      Field<ListGraphType<TaskType>>(
          "properties",
          resolve: context => taskRepository.GetAll());

      Field<TaskType>(
          "property",
          arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
          resolve: context => taskRepository.GetById(context.GetArgument<int>("id")));
  }
  ```

### Define the Types:

- Map your data models to GraphQL types, specifying fields and their characteristics.
  ```c#
  public class TaskType : ObjectGraphType<TaskDetails>
  {
      public TaskType()
      {
          Field(x => x.TaskID);
          Field(x => x.TaskName);
          Field(x => x.OwnerID, type: typeof(IdGraphType));
          Field(x => x.TaskDueDate);
          Field(x => x.AssignedTo);
          Field(x => x.AssignedBy);
          Field(x => x.TaskProjectID);
          Field(x => x.StatusType);
          Field(x => x.ExpectedHours);
          Field(x => x.BillableHours);
          Field(x => x.TaskPriorityID);
      }
  }
  ```

### Define GraphQL Schema:

- Combine queries, types, and (optionally) mutations into the overall schema.
  ```c#
  public class GraphQLSchema : GraphQL.Types.Schema
  {
      public GraphQLSchema(IDependencyResolver resolver) : base(resolver)
      {
          Query = resolver.Resolve<TaskQuery>();
      }
  }
  ```

### Define Repo Function Interface and Implementation:

- In the DAL/GraphQL folder, define the interface for data access and its implementation.

  Interface

  ```c#
      IEnumerable<TaskDetails> GetAll();
  ```

  Implementation

  ```c#
  public IEnumerable<TaskDetails> GetAll()
  {
      var connectionString = "Server=xxx;database=xxx;Uid=xxx;Pwd=xxx;Port=3306;SslMode=none";

      using (var db = new MySqlConnection(connectionString))
      {
          var result = db.Query<TaskDetails>("SELECT * FROM task_details limit 1000").ToList();
          return result;
      }
  }
  ```

### Run the Application:

- Build and run your project.

### Test using Postman:

- Use Postman to send GraphQL queries to your endpoint and verify the responses.
  ![Example Image](./images/postman.png)
