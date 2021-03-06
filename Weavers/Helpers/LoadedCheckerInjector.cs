using System.Linq;
using Mono.Cecil;

/// <summary>
/// Looks for the CheckIsLoaded method in IStorable types.
/// </summary>
public class MethodFinder
{
	ModuleDefinition moduleDefinition;
	public MethodDefinition Method;
	string methodName;
	int parameters;

	public MethodFinder (ModuleDefinition moduleDefinition, string methodName, int parameters)
	{
		this.moduleDefinition = moduleDefinition;
		this.parameters = parameters;
		this.methodName = methodName;
	}

	public MethodReference Execute (TypeDefinition type)
	{
		Method = FindMethod (type);
		if (Method != null) {
			if (Method.IsStatic) {
				throw new WeavingException (methodName + " method can no be static");
			}
			if (!Method.IsFamily) {
				throw new WeavingException (methodName + " method needs to be protected");
			}
			return  moduleDefinition.ImportReference (Method);
		} else {
			throw new WeavingException (methodName + " method not found for type " + type.Name);
		}
	}

	MethodDefinition FindMethod (TypeDefinition type)
	{
		MethodDefinition method = type.Methods.FirstOrDefault (IsMethod);
		if (method == null && type.BaseType != null) {
			return FindMethod (type.BaseType.Resolve ());
		}
		return method;
	}

	bool IsMethod (MethodDefinition method)
	{
		return method.Name == methodName && method.Parameters.Count == parameters;
	}

}