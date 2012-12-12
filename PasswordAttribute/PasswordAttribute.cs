using UnityEngine;
using System.Collections;
using System;

public class PasswordAttribute : PropertyAttribute
{

	public char mask = '*';
	public bool useMask = true;
	public int minLength = 0;
	public int maxLength = 2147483647;

	public PasswordAttribute ()
	{
	}

	public PasswordAttribute (int minLength, int maxLength)
	{
		this.minLength = minLength;
		this.maxLength = maxLength;
	}
	
	public PasswordAttribute (int minLength, bool useMask)
	{
		this.useMask = useMask;
		this.minLength = minLength;
	}
	
	public PasswordAttribute (int minLength, int maxLength, bool useMask)
	{
		this.useMask = useMask;
		this.minLength = minLength;
		this.maxLength = maxLength;
	}
}
