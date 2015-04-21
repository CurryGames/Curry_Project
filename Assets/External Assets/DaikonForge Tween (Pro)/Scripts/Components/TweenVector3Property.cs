﻿/* Copyright 2013-2014 Daikon Forge */
using UnityEngine;

using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

using DaikonForge.Tween;

#if !FREE_VERSION

namespace DaikonForge.Tween.Components
{

	/// <summary>
	/// Used to animate a named property of type Vector3
	/// </summary>
	[AddComponentMenu( "Daikon Forge/Tween/Named Vector3" )]
	public class TweenVector3Property : TweenPropertyComponent<Vector3>
	{
	}

}

#endif
