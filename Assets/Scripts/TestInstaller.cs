using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<string>().FromInstance("Hello World!");
		Container.Bind<Greeter>().AsSingle().NonLazy();
		Container.Bind<Foo>().AsSingle().OnInstantiated<Foo>(OnFooInstantiated);
	}

	

void OnFooInstantiated(InjectContext context, Foo foo)
	{
		foo.Qux = "asdf";

		Debug.Log(foo.Qux);
	}
}

public class Foo
{
	public string Qux;
}

public class Greeter
{
	[Inject] Foo foo;

	public Greeter(string message)
	{
		Debug.Log(message);
	}
}