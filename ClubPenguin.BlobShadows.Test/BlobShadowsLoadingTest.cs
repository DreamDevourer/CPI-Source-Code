using Disney.Kelowna.Common.Tests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ClubPenguin.BlobShadows.Tests
{
	public class BlobShadowsLoadingTest : BaseIntegrationTest
	{
		private sealed class _runTest_d__0 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private object __2__current;

			private int __1__state;

			public BlobShadowsLoadingTest __4__this;

			object IEnumerator<object>.Current
			{
				get
				{
					return this.__2__current;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					return this.__2__current;
				}
			}

			bool IEnumerator.MoveNext()
			{
				bool result;
				switch (this.__1__state)
				{
				case 0:
					this.__1__state = -1;
					this.__2__current = null;
					this.__1__state = 1;
					result = true;
					return result;
				case 1:
					this.__1__state = -1;
					break;
				}
				result = false;
				return result;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			public _runTest_d__0(int __1__state)
			{
				this.__1__state = __1__state;
			}
		}

		protected override IEnumerator runTest()
		{
			BlobShadowsLoadingTest._runTest_d__0 _runTest_d__ = new BlobShadowsLoadingTest._runTest_d__0(0);
			_runTest_d__.__4__this = this;
			return _runTest_d__;
		}
	}
}