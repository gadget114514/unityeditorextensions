<p align="center">
<img align="center" src="https://raw.githubusercontent.com/coryleach/UnityPackages/master/Documentation/GameframeFace.gif" />
</p>
<h1 align="center">Gameframe.SceneSwitcher 👋</h1>

<!-- BADGE-START -->
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/5e25869cd7c34f218c6483e496038da2)](https://www.codacy.com/manual/coryleach/UnitySceneSwitcher?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=coryleach/UnitySceneSwitcher&amp;utm_campaign=Badge_Grade)
![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/coryleach/UnitySceneSwitcher?include_prereleases)
[![openupm](https://img.shields.io/npm/v/com.gameframe.sceneswitcher?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.gameframe.sceneswitcher/)
![GitHub](https://img.shields.io/github/license/coryleach/UnitySceneSwitcher)

[![twitter](https://img.shields.io/twitter/follow/coryleach.svg?style=social)](https://twitter.com/coryleach)
<!-- BADGE-END -->

Unity editor window for quick scene switching.

## Quick Package Install

#### Using UnityPackageManager (for Unity 2019.3 or later)
Open the package manager window (menu: Window > Package Manager)<br/>
Select "Add package from git URL...", fill in the pop-up with the following link:<br/>
https://github.com/coryleach/UnitySceneSwitcher.git#1.0.2<br/>

#### Using UnityPackageManager (for Unity 2019.1 or later)

Find the manifest.json file in the Packages folder of your project and edit it to look like this:
```js
{
  "dependencies": {
    "com.gameframe.sceneswitcher": "https://github.com/coryleach/UnitySceneSwitcher.git#1.0.2",
    ...
  },
}
```

<!-- DOC-START -->
<!-- 
Changes between 'DOC START' and 'DOC END' will not be modified by readme update scripts
-->

## Usage

```sh
In the menu select Window -> SceneSwitcher
```

<p align="center">
  <img width="250" src="https://raw.githubusercontent.com/coryleach/UnitySceneSwitcher/master/Documentation~/img/Empty.png" />
  <img width="250" src="https://raw.githubusercontent.com/coryleach/UnitySceneSwitcher/master/Documentation~/img/DefaultMode.png" />
  <img width="250" src="https://raw.githubusercontent.com/coryleach/UnitySceneSwitcher/master/Documentation~/img/EditMode.png" />
</p>

<p>
  To enable edit mode use the hamburger menu at the top right of the window
</p>

```
AutoSort = Moves the most recently clicked button to the top of the list
Additive = Loads scene additively when the button is clicked
Close = Closes other scenes
```

##### Requirement

* Unity 2018.4 or later (Tested in Unity 2018.4.3f1)
* No other SDK are required

<!-- DOC-END -->

## Author

👤 **Cory Leach**

* Twitter: [@coryleach](https://twitter.com/coryleach)
* Github: [@coryleach](https://github.com/coryleach)


## Show your support

Give a ⭐️ if this project helped you!

***
_This README was generated with ❤️ by [Gameframe.Packages](https://github.com/coryleach/unitypackages)_
