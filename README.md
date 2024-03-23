# 👾 Design patterns in Unity 👾
In this repository I will be experimenting with different software design patterns. I will try to make a simple implementation for each pattern.

## Command

> We wrap the method call in a separate object.
> This allows us to do cool things like undo action,
> delayed execution and input change.

![Command pattern image](https://github.com/akihiko47/Design-Patterns/blob/main/images/command.png?raw=true)

In the game example, there are spheres that can be turned on with a left mouse click, change color with a right click and actions can be undone with the Z key.

## Flyweight

> We separate the common data across many objects into a separate object.

![Flyweight pattern image](https://github.com/akihiko47/Design-Patterns/blob/main/images/flyweight.png?raw=true)

One of the realizations of this pattern is Unity's Scriptable Objects. In Flyweight scene you can create objects using C, save positions using S, load with L and clear with N. This is from catlike coding tutorials and in general it's not really the realization of the pattern, but the main thing is that I understood it c:

## Observer

> Allows us to unlink objects from each other. When something interesting happens in an object, it does not care who receives the message.

![Observer pattern image](https://github.com/akihiko47/Design-Patterns/blob/main/images/observer.jpg?raw=true)

In the Observer example scene I give a simple example with a player. There is a subject player that notifies observers on some action. If you press the space bar, all the necessary managers will be triggered.