# Polly.Contrib.CustomPolicyTemplates

This repo contains blank templates for developing custom policies for use with the .NET resilience library [Polly](https://github.com/App-vNext/Polly).

### ReactiveCustomPolicyTemplate

The `ReactiveCustomPolicyTemplate` folder contains example code for a custom reactive Polly policy.

**Reactive policies** react to configured Exceptions or returned results. For instance, they might take some remediating action based on the fault, log it, or some other action.

eg `Policy.Handle<FooException>().FooReactivePolicy(...)`

### ProactiveCustomPolicyTemplate

The `ProactiveCustomPolicyTemplate` folder contains example code for a custom proactive Polly policy.

**Proactive policies** act for all executions, whether they involve a fault or success.  For instance, a policy to log execution duration (whatever the outcome) would be a proactive policy.

## How to use the templates

The code in this repo is extensively commented to show how policies fit together.

We have also published a series of four blog posts:

+ [Part I: Introducing custom Polly policies and the Polly.Contrib](http://www.thepollyproject.org/2019/02/13/introducing-custom-polly-policies-and-polly-contrib-custom-policies-part-i/)
+ [Part II: Authoring a non-reactive custom policy](http://www.thepollyproject.org/2019/02/13/authoring-a-proactive-polly-policy-custom-policies-part-ii/) (a policy which acts on all executions)
+ [Part III: Authoring a reactive custom policy](http://www.thepollyproject.org/2019/02/13/authoring-a-reactive-polly-policy-custom-policies-part-iii-2/) (a policy which react to faults)
+ [Part IV: Custom policies for all execution types](http://www.thepollyproject.org/2019/02/13/custom-policies-for-all-execution-types-custom-policies-part-iv/): sync and async, generic and non-generic

The main implementations are made in the `*Engine.cs` files; the other classes host your derived `Policy` classes (so that the policies can fit into [`PolicyWrap`](https://github.com/App-vNext/Polly/wiki/PolicyWrap)) and configuration syntax.

For examples of existing policy implementations, see:

+ [Polly.Contrib.TimingPolicy](https://github.com/Polly-Contrib/Polly.Contrib.TimingPolicy), an example proactive policy - links to blog Part II
+ [Polly.Contrib.LoggingPolicy](https://github.com/Polly-Contrib/Polly.Contrib.LoggingPolicy), an example reactive policy - links to blog Part III
+ the [main Polly repo](https://github.com/App-vNext/Polly/tree/master/src) - look in the sub-folders named by policy type (`Retry` etc), for any of the `*Engine.cs` files implementing policy behaviour


### To just explore how custom policies work

Fork this repo and dig in!  

To test your policy as you develop, you can drive your policy from unit-tests, or from a [simple console app, as Polly.Contrib.TimingPolicy demonstrates](https://github.com/Polly-Contrib/Polly.Contrib.TimingPolicy).

### To use a custom policy in your own app

Just reference [Polly nuget](https://nuget.org/packages/polly) (>=v7.0) in your app and follow the principles outlined in the examples.

(You don't need the `.sln` and `.csproj` structures in this repo - they just host the examples and show how to build to a nuget package.)

### To develop a policy to publish as a nuget package

The templates contain a build script that will build the custom policy into a nuget package.

If you want to publish your custom policy on nuget, we recommend bringing your contrib into the Polly.Contrib organisation - see below.

## Getting your contribution included in Polly.Contrib

Reach out to the Polly team at our [slack channel](http://pollytalk.slack.com) or the main [Polly project Github](https://github.com/App-vNext/Polly).

We can set up a repo in the Polly.Contrib organisation - you'll have full rights to this repo, to manage and deliver your awesomeness to the Polly community!

If you already have your custom policy in a github repo, we can also just move the existing repo into the Polly.Contrib org - you still retain full rights over the repo and management of the content, but the contrib gets  official recognition under the Polly.Contrib banner.

## Have a Contrib that isn't a policy?

If you have a contribution to Polly that isn't a policy - for example, a cache provider, or some wait-and-retry strategies - see instead our repo [Polly.Contrib.BlankTemplate](https://github.com/Polly-Contrib/Polly.Contrib.BlankTemplate).
