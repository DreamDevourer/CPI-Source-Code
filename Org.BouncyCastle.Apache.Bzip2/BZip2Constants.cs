// BZip2Constants
public class BZip2Constants
{
	public const int baseBlockSize = 100000;

	public const int MAX_ALPHA_SIZE = 258;

	public const int MAX_CODE_LEN = 23;

	public const int RUNA = 0;

	public const int RUNB = 1;

	public const int N_GROUPS = 6;

	public const int G_SIZE = 50;

	public const int N_ITERS = 4;

	public const int MAX_SELECTORS = 18002;

	public const int NUM_OVERSHOOT_BYTES = 20;

	public static readonly int[] rNums = new int[512]
	{
		619,
		720,
		127,
		481,
		931,
		816,
		813,
		233,
		566,
		247,
		985,
		724,
		205,
		454,
		863,
		491,
		741,
		242,
		949,
		214,
		733,
		859,
		335,
		708,
		621,
		574,
		73,
		654,
		730,
		472,
		419,
		436,
		278,
		496,
		867,
		210,
		399,
		680,
		480,
		51,
		878,
		465,
		811,
		169,
		869,
		675,
		611,
		697,
		867,
		561,
		862,
		687,
		507,
		283,
		482,
		129,
		807,
		591,
		733,
		623,
		150,
		238,
		59,
		379,
		684,
		877,
		625,
		169,
		643,
		105,
		170,
		607,
		520,
		932,
		727,
		476,
		693,
		425,
		174,
		647,
		73,
		122,
		335,
		530,
		442,
		853,
		695,
		249,
		445,
		515,
		909,
		545,
		703,
		919,
		874,
		474,
		882,
		500,
		594,
		612,
		641,
		801,
		220,
		162,
		819,
		984,
		589,
		513,
		495,
		799,
		161,
		604,
		958,
		533,
		221,
		400,
		386,
		867,
		600,
		782,
		382,
		596,
		414,
		171,
		516,
		375,
		682,
		485,
		911,
		276,
		98,
		553,
		163,
		354,
		666,
		933,
		424,
		341,
		533,
		870,
		227,
		730,
		475,
		186,
		263,
		647,
		537,
		686,
		600,
		224,
		469,
		68,
		770,
		919,
		190,
		373,
		294,
		822,
		808,
		206,
		184,
		943,
		795,
		384,
		383,
		461,
		404,
		758,
		839,
		887,
		715,
		67,
		618,
		276,
		204,
		918,
		873,
		777,
		604,
		560,
		951,
		160,
		578,
		722,
		79,
		804,
		96,
		409,
		713,
		940,
		652,
		934,
		970,
		447,
		318,
		353,
		859,
		672,
		112,
		785,
		645,
		863,
		803,
		350,
		139,
		93,
		354,
		99,
		820,
		908,
		609,
		772,
		154,
		274,
		580,
		184,
		79,
		626,
		630,
		742,
		653,
		282,
		762,
		623,
		680,
		81,
		927,
		626,
		789,
		125,
		411,
		521,
		938,
		300,
		821,
		78,
		343,
		175,
		128,
		250,
		170,
		774,
		972,
		275,
		999,
		639,
		495,
		78,
		352,
		126,
		857,
		956,
		358,
		619,
		580,
		124,
		737,
		594,
		701,
		612,
		669,
		112,
		134,
		694,
		363,
		992,
		809,
		743,
		168,
		974,
		944,
		375,
		748,
		52,
		600,
		747,
		642,
		182,
		862,
		81,
		344,
		805,
		988,
		739,
		511,
		655,
		814,
		334,
		249,
		515,
		897,
		955,
		664,
		981,
		649,
		113,
		974,
		459,
		893,
		228,
		433,
		837,
		553,
		268,
		926,
		240,
		102,
		654,
		459,
		51,
		686,
		754,
		806,
		760,
		493,
		403,
		415,
		394,
		687,
		700,
		946,
		670,
		656,
		610,
		738,
		392,
		760,
		799,
		887,
		653,
		978,
		321,
		576,
		617,
		626,
		502,
		894,
		679,
		243,
		440,
		680,
		879,
		194,
		572,
		640,
		724,
		926,
		56,
		204,
		700,
		707,
		151,
		457,
		449,
		797,
		195,
		791,
		558,
		945,
		679,
		297,
		59,
		87,
		824,
		713,
		663,
		412,
		693,
		342,
		606,
		134,
		108,
		571,
		364,
		631,
		212,
		174,
		643,
		304,
		329,
		343,
		97,
		430,
		751,
		497,
		314,
		983,
		374,
		822,
		928,
		140,
		206,
		73,
		263,
		980,
		736,
		876,
		478,
		430,
		305,
		170,
		514,
		364,
		692,
		829,
		82,
		855,
		953,
		676,
		246,
		369,
		970,
		294,
		750,
		807,
		827,
		150,
		790,
		288,
		923,
		804,
		378,
		215,
		828,
		592,
		281,
		565,
		555,
		710,
		82,
		896,
		831,
		547,
		261,
		524,
		462,
		293,
		465,
		502,
		56,
		661,
		821,
		976,
		991,
		658,
		869,
		905,
		758,
		745,
		193,
		768,
		550,
		608,
		933,
		378,
		286,
		215,
		979,
		792,
		961,
		61,
		688,
		793,
		644,
		986,
		403,
		106,
		366,
		905,
		644,
		372,
		567,
		466,
		434,
		645,
		210,
		389,
		550,
		919,
		135,
		780,
		773,
		635,
		389,
		707,
		100,
		626,
		958,
		165,
		504,
		920,
		176,
		193,
		713,
		857,
		265,
		203,
		50,
		668,
		108,
		645,
		990,
		626,
		197,
		510,
		357,
		358,
		850,
		858,
		364,
		936,
		638
	};
}

// CBZip2InputStream
using Org.BouncyCastle.Apache.Bzip2;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

public class CBZip2InputStream : Stream
{
	private const int START_BLOCK_STATE = 1;

	private const int RAND_PART_A_STATE = 2;

	private const int RAND_PART_B_STATE = 3;

	private const int RAND_PART_C_STATE = 4;

	private const int NO_RAND_PART_A_STATE = 5;

	private const int NO_RAND_PART_B_STATE = 6;

	private const int NO_RAND_PART_C_STATE = 7;

	private int last;

	private int origPtr;

	private int blockSize100k;

	private bool blockRandomised;

	private int bsBuff;

	private int bsLive;

	private CRC mCrc = new CRC();

	private bool[] inUse = new bool[256];

	private int nInUse;

	private char[] seqToUnseq = new char[256];

	private char[] unseqToSeq = new char[256];

	private char[] selector = new char[18002];

	private char[] selectorMtf = new char[18002];

	private int[] tt;

	private char[] ll8;

	private int[] unzftab = new int[256];

	private int[][] limit = InitIntArray(6, 258);

	private int[][] basev = InitIntArray(6, 258);

	private int[][] perm = InitIntArray(6, 258);

	private int[] minLens = new int[6];

	private Stream bsStream;

	private bool streamEnd = false;

	private int currentChar = -1;

	private int currentState = 1;

	private int storedBlockCRC;

	private int storedCombinedCRC;

	private int computedBlockCRC;

	private int computedCombinedCRC;

	private int i2;

	private int count;

	private int chPrev;

	private int ch2;

	private int i;

	private int tPos;

	private int rNToGo = 0;

	private int rTPos = 0;

	private int j2;

	private char z;

	public override bool CanRead => true;

	public override bool CanSeek => false;

	public override bool CanWrite => false;

	public override long Length => 0L;

	public override long Position
	{
		get
		{
			return 0L;
		}
		set
		{
		}
	}

	private static void Cadvise()
	{
	}

	private static void CompressedStreamEOF()
	{
		Cadvise();
	}

	private void MakeMaps()
	{
		nInUse = 0;
		for (int i = 0; i < 256; i++)
		{
			if (inUse[i])
			{
				seqToUnseq[nInUse] = (char)i;
				unseqToSeq[i] = (char)nInUse;
				nInUse++;
			}
		}
	}

	public CBZip2InputStream(Stream zStream)
	{
		ll8 = null;
		tt = null;
		BsSetStream(zStream);
		Initialize();
		InitBlock();
		SetupBlock();
	}

	internal static int[][] InitIntArray(int n1, int n2)
	{
		int[][] array = new int[n1][];
		for (int i = 0; i < n1; i++)
		{
			array[i] = new int[n2];
		}
		return array;
	}

	internal static char[][] InitCharArray(int n1, int n2)
	{
		char[][] array = new char[n1][];
		for (int i = 0; i < n1; i++)
		{
			array[i] = new char[n2];
		}
		return array;
	}

	public override int ReadByte()
	{
		if (streamEnd)
		{
			return -1;
		}
		int result = currentChar;
		switch (currentState)
		{
		case 3:
			SetupRandPartB();
			break;
		case 4:
			SetupRandPartC();
			break;
		case 6:
			SetupNoRandPartB();
			break;
		case 7:
			SetupNoRandPartC();
			break;
		}
		return result;
	}

	private void Initialize()
	{
		char c = BsGetUChar();
		char c2 = BsGetUChar();
		if (c != 'B' && c2 != 'Z')
		{
			throw new IOException("Not a BZIP2 marked stream");
		}
		c = BsGetUChar();
		c2 = BsGetUChar();
		if (c != 'h' || c2 < '1' || c2 > '9')
		{
			BsFinishedWithStream();
			streamEnd = true;
		}
		else
		{
			SetDecompressStructureSizes(c2 - 48);
			computedCombinedCRC = 0;
		}
	}

	private void InitBlock()
	{
		char c = BsGetUChar();
		char c2 = BsGetUChar();
		char c3 = BsGetUChar();
		char c4 = BsGetUChar();
		char c5 = BsGetUChar();
		char c6 = BsGetUChar();
		if (c == '\u0017' && c2 == 'r' && c3 == 'E' && c4 == '8' && c5 == 'P' && c6 == '\u0090')
		{
			Complete();
			return;
		}
		if (c != '1' || c2 != 'A' || c3 != 'Y' || c4 != '&' || c5 != 'S' || c6 != 'Y')
		{
			BadBlockHeader();
			streamEnd = true;
			return;
		}
		storedBlockCRC = BsGetInt32();
		if (BsR(1) == 1)
		{
			blockRandomised = true;
		}
		else
		{
			blockRandomised = false;
		}
		GetAndMoveToFrontDecode();
		mCrc.InitialiseCRC();
		currentState = 1;
	}

	private void EndBlock()
	{
		computedBlockCRC = mCrc.GetFinalCRC();
		if (storedBlockCRC != computedBlockCRC)
		{
			CrcError();
		}
		computedCombinedCRC = ((computedCombinedCRC << 1) | (int)((uint)computedCombinedCRC >> 31));
		computedCombinedCRC ^= computedBlockCRC;
	}

	private void Complete()
	{
		storedCombinedCRC = BsGetInt32();
		if (storedCombinedCRC != computedCombinedCRC)
		{
			CrcError();
		}
		BsFinishedWithStream();
		streamEnd = true;
	}

	private static void BlockOverrun()
	{
		Cadvise();
	}

	private static void BadBlockHeader()
	{
		Cadvise();
	}

	private static void CrcError()
	{
		Cadvise();
	}

	private void BsFinishedWithStream()
	{
		try
		{
			if (bsStream != null)
			{
				Platform.Dispose(bsStream);
				bsStream = null;
			}
		}
		catch
		{
		}
	}

	private void BsSetStream(Stream f)
	{
		bsStream = f;
		bsLive = 0;
		bsBuff = 0;
	}

	private int BsR(int n)
	{
		while (bsLive < n)
		{
			char c = '\0';
			try
			{
				c = (char)bsStream.ReadByte();
			}
			catch (IOException)
			{
				CompressedStreamEOF();
			}
			if (c == '\uffff')
			{
				CompressedStreamEOF();
			}
			int num = c;
			bsBuff = ((bsBuff << 8) | (num & 0xFF));
			bsLive += 8;
		}
		int result = (bsBuff >> bsLive - n) & ((1 << n) - 1);
		bsLive -= n;
		return result;
	}

	private char BsGetUChar()
	{
		return (char)BsR(8);
	}

	private int BsGetint()
	{
		int num = 0;
		num = ((num << 8) | BsR(8));
		num = ((num << 8) | BsR(8));
		num = ((num << 8) | BsR(8));
		return (num << 8) | BsR(8);
	}

	private int BsGetIntVS(int numBits)
	{
		return BsR(numBits);
	}

	private int BsGetInt32()
	{
		return BsGetint();
	}

	private void HbCreateDecodeTables(int[] limit, int[] basev, int[] perm, char[] length, int minLen, int maxLen, int alphaSize)
	{
		int num = 0;
		for (int i = minLen; i <= maxLen; i++)
		{
			for (int j = 0; j < alphaSize; j++)
			{
				if (length[j] == i)
				{
					perm[num] = j;
					num++;
				}
			}
		}
		for (int i = 0; i < 23; i++)
		{
			basev[i] = 0;
		}
		for (int i = 0; i < alphaSize; i++)
		{
			int[] array;
			int[] array2 = array = basev;
			int num2 = length[i] + 1;
			IntPtr intPtr = (IntPtr)num2;
			array2[num2] = array[(long)intPtr] + 1;
		}
		for (int i = 1; i < 23; i++)
		{
			int[] array;
			int[] array3 = array = basev;
			int num3 = i;
			IntPtr intPtr = (IntPtr)num3;
			array3[num3] = array[(long)intPtr] + basev[i - 1];
		}
		for (int i = 0; i < 23; i++)
		{
			limit[i] = 0;
		}
		int num4 = 0;
		for (int i = minLen; i <= maxLen; i++)
		{
			num4 += basev[i + 1] - basev[i];
			limit[i] = num4 - 1;
			num4 <<= 1;
		}
		for (int i = minLen + 1; i <= maxLen; i++)
		{
			basev[i] = (limit[i - 1] + 1 << 1) - basev[i];
		}
	}

	private void RecvDecodingTables()
	{
		char[][] array = InitCharArray(6, 258);
		bool[] array2 = new bool[16];
		for (int i = 0; i < 16; i++)
		{
			if (BsR(1) == 1)
			{
				array2[i] = true;
			}
			else
			{
				array2[i] = false;
			}
		}
		for (int i = 0; i < 256; i++)
		{
			inUse[i] = false;
		}
		for (int i = 0; i < 16; i++)
		{
			if (!array2[i])
			{
				continue;
			}
			for (int j = 0; j < 16; j++)
			{
				if (BsR(1) == 1)
				{
					inUse[i * 16 + j] = true;
				}
			}
		}
		MakeMaps();
		int num = nInUse + 2;
		int num2 = BsR(3);
		int num3 = BsR(15);
		for (int i = 0; i < num3; i++)
		{
			int j = 0;
			while (BsR(1) == 1)
			{
				j++;
			}
			selectorMtf[i] = (char)j;
		}
		char[] array3 = new char[6];
		for (char c = '\0'; c < num2; c = (char)(c + 1))
		{
			array3[c] = c;
		}
		for (int i = 0; i < num3; i++)
		{
			char c = selectorMtf[i];
			char c2 = array3[c];
			while (c > '\0')
			{
				array3[c] = array3[c - 1];
				c = (char)(c - 1);
			}
			array3[0] = c2;
			selector[i] = c2;
		}
		for (int k = 0; k < num2; k++)
		{
			int num4 = BsR(5);
			for (int i = 0; i < num; i++)
			{
				while (BsR(1) == 1)
				{
					num4 = ((BsR(1) != 0) ? (num4 - 1) : (num4 + 1));
				}
				array[k][i] = (char)num4;
			}
		}
		for (int k = 0; k < num2; k++)
		{
			int num5 = 32;
			int num6 = 0;
			for (int i = 0; i < num; i++)
			{
				if (array[k][i] > num6)
				{
					num6 = array[k][i];
				}
				if (array[k][i] < num5)
				{
					num5 = array[k][i];
				}
			}
			HbCreateDecodeTables(limit[k], basev[k], perm[k], array[k], num5, num6, num);
			minLens[k] = num5;
		}
	}

	private void GetAndMoveToFrontDecode()
	{
		char[] array = new char[256];
		int num = 100000 * blockSize100k;
		origPtr = BsGetIntVS(24);
		RecvDecodingTables();
		int num2 = nInUse + 1;
		int num3 = -1;
		int num4 = 0;
		for (int i = 0; i <= 255; i++)
		{
			unzftab[i] = 0;
		}
		for (int i = 0; i <= 255; i++)
		{
			array[i] = (char)i;
		}
		last = -1;
		if (num4 == 0)
		{
			num3++;
			num4 = 50;
		}
		num4--;
		int num5 = selector[num3];
		int num6 = minLens[num5];
		int num7;
		int num9;
		for (num7 = BsR(num6); num7 > limit[num5][num6]; num7 = ((num7 << 1) | num9))
		{
			num6++;
			while (bsLive < 1)
			{
				char c = '\0';
				try
				{
					c = (char)bsStream.ReadByte();
				}
				catch (IOException)
				{
					CompressedStreamEOF();
				}
				if (c == '\uffff')
				{
					CompressedStreamEOF();
				}
				int num8 = c;
				bsBuff = ((bsBuff << 8) | (num8 & 0xFF));
				bsLive += 8;
			}
			num9 = ((bsBuff >> bsLive - 1) & 1);
			bsLive--;
		}
		int num10 = perm[num5][num7 - basev[num5][num6]];
		while (num10 != num2)
		{
			int[] array2;
			IntPtr intPtr;
			if (num10 == 0 || num10 == 1)
			{
				int num11 = -1;
				int num12 = 1;
				do
				{
					switch (num10)
					{
					case 0:
						num11 += num12;
						break;
					case 1:
						num11 += 2 * num12;
						break;
					}
					num12 *= 2;
					if (num4 == 0)
					{
						num3++;
						num4 = 50;
					}
					num4--;
					int num13 = selector[num3];
					int num14 = minLens[num13];
					int num15;
					int num17;
					for (num15 = BsR(num14); num15 > limit[num13][num14]; num15 = ((num15 << 1) | num17))
					{
						num14++;
						while (bsLive < 1)
						{
							char c2 = '\0';
							try
							{
								c2 = (char)bsStream.ReadByte();
							}
							catch (IOException)
							{
								CompressedStreamEOF();
							}
							if (c2 == '\uffff')
							{
								CompressedStreamEOF();
							}
							int num16 = c2;
							bsBuff = ((bsBuff << 8) | (num16 & 0xFF));
							bsLive += 8;
						}
						num17 = ((bsBuff >> bsLive - 1) & 1);
						bsLive--;
					}
					num10 = perm[num13][num15 - basev[num13][num14]];
				}
				while (num10 == 0 || num10 == 1);
				num11++;
				char c3 = seqToUnseq[array[0]];
				int[] array3 = array2 = unzftab;
				char num18 = c3;
				intPtr = (IntPtr)(int)num18;
				array3[num18] = array2[(long)intPtr] + num11;
				while (num11 > 0)
				{
					last++;
					ll8[last] = c3;
					num11--;
				}
				if (last >= num)
				{
					BlockOverrun();
				}
				continue;
			}
			last++;
			if (last >= num)
			{
				BlockOverrun();
			}
			char c4 = array[num10 - 1];
			int[] array4 = array2 = unzftab;
			char num19 = seqToUnseq[c4];
			intPtr = (IntPtr)(int)num19;
			array4[num19] = array2[(long)intPtr] + 1;
			ll8[last] = seqToUnseq[c4];
			int num20;
			for (num20 = num10 - 1; num20 > 3; num20 -= 4)
			{
				array[num20] = array[num20 - 1];
				array[num20 - 1] = array[num20 - 2];
				array[num20 - 2] = array[num20 - 3];
				array[num20 - 3] = array[num20 - 4];
			}
			while (num20 > 0)
			{
				array[num20] = array[num20 - 1];
				num20--;
			}
			array[0] = c4;
			if (num4 == 0)
			{
				num3++;
				num4 = 50;
			}
			num4--;
			int num21 = selector[num3];
			int num22 = minLens[num21];
			int num23;
			int num25;
			for (num23 = BsR(num22); num23 > limit[num21][num22]; num23 = ((num23 << 1) | num25))
			{
				num22++;
				while (bsLive < 1)
				{
					char c5 = '\0';
					try
					{
						c5 = (char)bsStream.ReadByte();
					}
					catch (IOException)
					{
						CompressedStreamEOF();
					}
					int num24 = c5;
					bsBuff = ((bsBuff << 8) | (num24 & 0xFF));
					bsLive += 8;
				}
				num25 = ((bsBuff >> bsLive - 1) & 1);
				bsLive--;
			}
			num10 = perm[num21][num23 - basev[num21][num22]];
		}
	}

	private void SetupBlock()
	{
		int[] array = new int[257]
		{
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};
		for (i = 1; i <= 256; i++)
		{
			array[i] = unzftab[i - 1];
		}
		for (i = 1; i <= 256; i++)
		{
			int[] array2;
			int[] array3 = array2 = array;
			int num = i;
			IntPtr intPtr = (IntPtr)num;
			array3[num] = array2[(long)intPtr] + array[i - 1];
		}
		for (i = 0; i <= last; i++)
		{
			char c = ll8[i];
			tt[array[c]] = i;
			int[] array2;
			int[] array4 = array2 = array;
			char num2 = c;
			IntPtr intPtr = (IntPtr)(int)num2;
			array4[num2] = array2[(long)intPtr] + 1;
		}
		array = null;
		tPos = tt[origPtr];
		count = 0;
		i2 = 0;
		ch2 = 256;
		if (blockRandomised)
		{
			rNToGo = 0;
			rTPos = 0;
			SetupRandPartA();
		}
		else
		{
			SetupNoRandPartA();
		}
	}

	private void SetupRandPartA()
	{
		if (i2 <= last)
		{
			chPrev = ch2;
			ch2 = ll8[tPos];
			tPos = tt[tPos];
			if (rNToGo == 0)
			{
				rNToGo = BZip2Constants.rNums[rTPos];
				rTPos++;
				if (rTPos == 512)
				{
					rTPos = 0;
				}
			}
			rNToGo--;
			ch2 ^= ((rNToGo == 1) ? 1 : 0);
			i2++;
			currentChar = ch2;
			currentState = 3;
			mCrc.UpdateCRC(ch2);
		}
		else
		{
			EndBlock();
			InitBlock();
			SetupBlock();
		}
	}

	private void SetupNoRandPartA()
	{
		if (i2 <= last)
		{
			chPrev = ch2;
			ch2 = ll8[tPos];
			tPos = tt[tPos];
			i2++;
			currentChar = ch2;
			currentState = 6;
			mCrc.UpdateCRC(ch2);
		}
		else
		{
			EndBlock();
			InitBlock();
			SetupBlock();
		}
	}

	private void SetupRandPartB()
	{
		if (ch2 != chPrev)
		{
			currentState = 2;
			count = 1;
			SetupRandPartA();
			return;
		}
		count++;
		if (count >= 4)
		{
			z = ll8[tPos];
			tPos = tt[tPos];
			if (rNToGo == 0)
			{
				rNToGo = BZip2Constants.rNums[rTPos];
				rTPos++;
				if (rTPos == 512)
				{
					rTPos = 0;
				}
			}
			rNToGo--;
			z ^= (char)(ushort)((rNToGo == 1) ? 1 : 0);
			j2 = 0;
			currentState = 4;
			SetupRandPartC();
		}
		else
		{
			currentState = 2;
			SetupRandPartA();
		}
	}

	private void SetupRandPartC()
	{
		if (j2 < z)
		{
			currentChar = ch2;
			mCrc.UpdateCRC(ch2);
			j2++;
		}
		else
		{
			currentState = 2;
			i2++;
			count = 0;
			SetupRandPartA();
		}
	}

	private void SetupNoRandPartB()
	{
		if (ch2 != chPrev)
		{
			currentState = 5;
			count = 1;
			SetupNoRandPartA();
			return;
		}
		count++;
		if (count >= 4)
		{
			z = ll8[tPos];
			tPos = tt[tPos];
			currentState = 7;
			j2 = 0;
			SetupNoRandPartC();
		}
		else
		{
			currentState = 5;
			SetupNoRandPartA();
		}
	}

	private void SetupNoRandPartC()
	{
		if (j2 < z)
		{
			currentChar = ch2;
			mCrc.UpdateCRC(ch2);
			j2++;
		}
		else
		{
			currentState = 5;
			i2++;
			count = 0;
			SetupNoRandPartA();
		}
	}

	private void SetDecompressStructureSizes(int newSize100k)
	{
		if (0 <= newSize100k && newSize100k <= 9 && 0 <= blockSize100k)
		{
			int blockSize100k2 = blockSize100k;
		}
		blockSize100k = newSize100k;
		if (newSize100k != 0)
		{
			int num = 100000 * newSize100k;
			ll8 = new char[num];
			tt = new int[num];
		}
	}

	public override void Flush()
	{
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int num = -1;
		int i;
		for (i = 0; i < count; i++)
		{
			num = ReadByte();
			if (num == -1)
			{
				break;
			}
			buffer[i + offset] = (byte)num;
		}
		return i;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return 0L;
	}

	public override void SetLength(long value)
	{
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
	}
}

// CBZip2OutputStream
using Org.BouncyCastle.Apache.Bzip2;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

public class CBZip2OutputStream : Stream
{
	internal class StackElem
	{
		internal int ll;

		internal int hh;

		internal int dd;
	}

	protected const int SETMASK = 2097152;

	protected const int CLEARMASK = -2097153;

	protected const int GREATER_ICOST = 15;

	protected const int LESSER_ICOST = 0;

	protected const int SMALL_THRESH = 20;

	protected const int DEPTH_THRESH = 10;

	protected const int QSORT_STACK_SIZE = 1000;

	private bool finished;

	private int last;

	private int origPtr;

	private int blockSize100k;

	private bool blockRandomised;

	private int bytesOut;

	private int bsBuff;

	private int bsLive;

	private CRC mCrc = new CRC();

	private bool[] inUse = new bool[256];

	private int nInUse;

	private char[] seqToUnseq = new char[256];

	private char[] unseqToSeq = new char[256];

	private char[] selector = new char[18002];

	private char[] selectorMtf = new char[18002];

	private char[] block;

	private int[] quadrant;

	private int[] zptr;

	private short[] szptr;

	private int[] ftab;

	private int nMTF;

	private int[] mtfFreq = new int[258];

	private int workFactor;

	private int workDone;

	private int workLimit;

	private bool firstAttempt;

	private int nBlocksRandomised;

	private int currentChar = -1;

	private int runLength = 0;

	private bool closed = false;

	private int blockCRC;

	private int combinedCRC;

	private int allowableBlockSize;

	private Stream bsStream;

	private int[] incs = new int[14]
	{
		1,
		4,
		13,
		40,
		121,
		364,
		1093,
		3280,
		9841,
		29524,
		88573,
		265720,
		797161,
		2391484
	};

	public override bool CanRead => false;

	public override bool CanSeek => false;

	public override bool CanWrite => true;

	public override long Length => 0L;

	public override long Position
	{
		get
		{
			return 0L;
		}
		set
		{
		}
	}

	private static void Panic()
	{
	}

	private void MakeMaps()
	{
		nInUse = 0;
		for (int i = 0; i < 256; i++)
		{
			if (inUse[i])
			{
				seqToUnseq[nInUse] = (char)i;
				unseqToSeq[i] = (char)nInUse;
				nInUse++;
			}
		}
	}

	protected static void HbMakeCodeLengths(char[] len, int[] freq, int alphaSize, int maxLen)
	{
		int[] array = new int[260];
		int[] array2 = new int[516];
		int[] array3 = new int[516];
		for (int i = 0; i < alphaSize; i++)
		{
			array2[i + 1] = ((freq[i] == 0) ? 1 : freq[i]) << 8;
		}
		while (true)
		{
			int num = alphaSize;
			int num2 = 0;
			array[0] = 0;
			array2[0] = 0;
			array3[0] = -2;
			for (int i = 1; i <= alphaSize; i++)
			{
				array3[i] = -1;
				num2++;
				array[num2] = i;
				int num3 = num2;
				int num4 = array[num3];
				while (array2[num4] < array2[array[num3 >> 1]])
				{
					array[num3] = array[num3 >> 1];
					num3 >>= 1;
				}
				array[num3] = num4;
			}
			if (num2 >= 260)
			{
				Panic();
			}
			while (num2 > 1)
			{
				int num5 = array[1];
				array[1] = array[num2];
				num2--;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				num6 = 1;
				num8 = array[num6];
				while (true)
				{
					num7 = num6 << 1;
					if (num7 > num2)
					{
						break;
					}
					if (num7 < num2 && array2[array[num7 + 1]] < array2[array[num7]])
					{
						num7++;
					}
					if (array2[num8] < array2[array[num7]])
					{
						break;
					}
					array[num6] = array[num7];
					num6 = num7;
				}
				array[num6] = num8;
				int num9 = array[1];
				array[1] = array[num2];
				num2--;
				int num10 = 0;
				int num11 = 0;
				int num12 = 0;
				num10 = 1;
				num12 = array[num10];
				while (true)
				{
					num11 = num10 << 1;
					if (num11 > num2)
					{
						break;
					}
					if (num11 < num2 && array2[array[num11 + 1]] < array2[array[num11]])
					{
						num11++;
					}
					if (array2[num12] < array2[array[num11]])
					{
						break;
					}
					array[num10] = array[num11];
					num10 = num11;
				}
				array[num10] = num12;
				num++;
				array3[num5] = (array3[num9] = num);
				array2[num] = ((int)((array2[num5] & 4294967040u) + (array2[num9] & 4294967040u)) | (1 + (((array2[num5] & 0xFF) > (array2[num9] & 0xFF)) ? (array2[num5] & 0xFF) : (array2[num9] & 0xFF))));
				array3[num] = -1;
				num2++;
				array[num2] = num;
				int num13 = 0;
				int num14 = 0;
				num13 = num2;
				num14 = array[num13];
				while (array2[num14] < array2[array[num13 >> 1]])
				{
					array[num13] = array[num13 >> 1];
					num13 >>= 1;
				}
				array[num13] = num14;
			}
			if (num >= 516)
			{
				Panic();
			}
			bool flag = false;
			for (int i = 1; i <= alphaSize; i++)
			{
				int num15 = 0;
				int num16 = i;
				while (array3[num16] >= 0)
				{
					num16 = array3[num16];
					num15++;
				}
				len[i - 1] = (char)num15;
				if (num15 > maxLen)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				break;
			}
			for (int i = 1; i < alphaSize; i++)
			{
				int num15 = array2[i] >> 8;
				num15 = 1 + num15 / 2;
				array2[i] = num15 << 8;
			}
		}
	}

	public CBZip2OutputStream(Stream inStream)
		: this(inStream, 9)
	{
	}

	public CBZip2OutputStream(Stream inStream, int inBlockSize)
	{
		block = null;
		quadrant = null;
		zptr = null;
		ftab = null;
		inStream.WriteByte(66);
		inStream.WriteByte(90);
		BsSetStream(inStream);
		workFactor = 50;
		if (inBlockSize > 9)
		{
			inBlockSize = 9;
		}
		if (inBlockSize < 1)
		{
			inBlockSize = 1;
		}
		blockSize100k = inBlockSize;
		AllocateCompressStructures();
		Initialize();
		InitBlock();
	}

	public override void WriteByte(byte bv)
	{
		int num = (256 + bv) % 256;
		if (currentChar != -1)
		{
			if (currentChar == num)
			{
				runLength++;
				if (runLength > 254)
				{
					WriteRun();
					currentChar = -1;
					runLength = 0;
				}
			}
			else
			{
				WriteRun();
				runLength = 1;
				currentChar = num;
			}
		}
		else
		{
			currentChar = num;
			runLength++;
		}
	}

	private void WriteRun()
	{
		if (last < allowableBlockSize)
		{
			inUse[currentChar] = true;
			for (int i = 0; i < runLength; i++)
			{
				mCrc.UpdateCRC((ushort)currentChar);
			}
			switch (runLength)
			{
			case 1:
				last++;
				block[last + 1] = (char)currentChar;
				break;
			case 2:
				last++;
				block[last + 1] = (char)currentChar;
				last++;
				block[last + 1] = (char)currentChar;
				break;
			case 3:
				last++;
				block[last + 1] = (char)currentChar;
				last++;
				block[last + 1] = (char)currentChar;
				last++;
				block[last + 1] = (char)currentChar;
				break;
			default:
				inUse[runLength - 4] = true;
				last++;
				block[last + 1] = (char)currentChar;
				last++;
				block[last + 1] = (char)currentChar;
				last++;
				block[last + 1] = (char)currentChar;
				last++;
				block[last + 1] = (char)currentChar;
				last++;
				block[last + 1] = (char)(runLength - 4);
				break;
			}
		}
		else
		{
			EndBlock();
			InitBlock();
			WriteRun();
		}
	}

	public override void Close()
	{
		if (!closed)
		{
			Finish();
			closed = true;
			Platform.Dispose(bsStream);
			base.Close();
		}
	}

	public void Finish()
	{
		if (!finished)
		{
			if (runLength > 0)
			{
				WriteRun();
			}
			currentChar = -1;
			EndBlock();
			EndCompression();
			finished = true;
			Flush();
		}
	}

	public override void Flush()
	{
		bsStream.Flush();
	}

	private void Initialize()
	{
		bytesOut = 0;
		nBlocksRandomised = 0;
		BsPutUChar(104);
		BsPutUChar(48 + blockSize100k);
		combinedCRC = 0;
	}

	private void InitBlock()
	{
		mCrc.InitialiseCRC();
		last = -1;
		for (int i = 0; i < 256; i++)
		{
			inUse[i] = false;
		}
		allowableBlockSize = 100000 * blockSize100k - 20;
	}

	private void EndBlock()
	{
		blockCRC = mCrc.GetFinalCRC();
		combinedCRC = ((combinedCRC << 1) | (int)((uint)combinedCRC >> 31));
		combinedCRC ^= blockCRC;
		DoReversibleTransformation();
		BsPutUChar(49);
		BsPutUChar(65);
		BsPutUChar(89);
		BsPutUChar(38);
		BsPutUChar(83);
		BsPutUChar(89);
		BsPutint(blockCRC);
		if (blockRandomised)
		{
			BsW(1, 1);
			nBlocksRandomised++;
		}
		else
		{
			BsW(1, 0);
		}
		MoveToFrontCodeAndSend();
	}

	private void EndCompression()
	{
		BsPutUChar(23);
		BsPutUChar(114);
		BsPutUChar(69);
		BsPutUChar(56);
		BsPutUChar(80);
		BsPutUChar(144);
		BsPutint(combinedCRC);
		BsFinishedWithStream();
	}

	private void HbAssignCodes(int[] code, char[] length, int minLen, int maxLen, int alphaSize)
	{
		int num = 0;
		for (int i = minLen; i <= maxLen; i++)
		{
			for (int j = 0; j < alphaSize; j++)
			{
				if (length[j] == i)
				{
					code[j] = num;
					num++;
				}
			}
			num <<= 1;
		}
	}

	private void BsSetStream(Stream f)
	{
		bsStream = f;
		bsLive = 0;
		bsBuff = 0;
		bytesOut = 0;
	}

	private void BsFinishedWithStream()
	{
		while (bsLive > 0)
		{
			int num = bsBuff >> 24;
			try
			{
				bsStream.WriteByte((byte)num);
			}
			catch (IOException ex)
			{
				throw ex;
			}
			bsBuff <<= 8;
			bsLive -= 8;
			bytesOut++;
		}
	}

	private void BsW(int n, int v)
	{
		while (bsLive >= 8)
		{
			int num = bsBuff >> 24;
			try
			{
				bsStream.WriteByte((byte)num);
			}
			catch (IOException ex)
			{
				throw ex;
			}
			bsBuff <<= 8;
			bsLive -= 8;
			bytesOut++;
		}
		bsBuff |= v << 32 - bsLive - n;
		bsLive += n;
	}

	private void BsPutUChar(int c)
	{
		BsW(8, c);
	}

	private void BsPutint(int u)
	{
		BsW(8, (u >> 24) & 0xFF);
		BsW(8, (u >> 16) & 0xFF);
		BsW(8, (u >> 8) & 0xFF);
		BsW(8, u & 0xFF);
	}

	private void BsPutIntVS(int numBits, int c)
	{
		BsW(numBits, c);
	}

	private unsafe void SendMTFValues()
	{
		char[][] array = CBZip2InputStream.InitCharArray(6, 258);
		int num = 0;
		int num2 = nInUse + 2;
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				array[i][j] = '\u000f';
			}
		}
		if (nMTF <= 0)
		{
			Panic();
		}
		int num3 = (nMTF < 200) ? 2 : ((nMTF < 600) ? 3 : ((nMTF < 1200) ? 4 : ((nMTF >= 2400) ? 6 : 5)));
		int num4 = num3;
		int num5 = nMTF;
		int num6 = 0;
		while (num4 > 0)
		{
			int num7 = num5 / num4;
			int num8 = num6 - 1;
			int k;
			for (k = 0; k < num7; k += mtfFreq[num8])
			{
				if (num8 >= num2 - 1)
				{
					break;
				}
				num8++;
			}
			if (num8 > num6 && num4 != num3 && num4 != 1 && (num3 - num4) % 2 == 1)
			{
				k -= mtfFreq[num8];
				num8--;
			}
			for (int j = 0; j < num2; j++)
			{
				if (j >= num6 && j <= num8)
				{
					array[num4 - 1][j] = '\0';
				}
				else
				{
					array[num4 - 1][j] = '\u000f';
				}
			}
			num4--;
			num6 = num8 + 1;
			num5 -= k;
		}
		int[][] array2 = CBZip2InputStream.InitIntArray(6, 258);
		int[] array3 = new int[6];
		short[] array4 = new short[6];
		for (int l = 0; l < 4; l++)
		{
			for (int i = 0; i < num3; i++)
			{
				array3[i] = 0;
			}
			for (int i = 0; i < num3; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					array2[i][j] = 0;
				}
			}
			num = 0;
			int num9 = 0;
			int num8;
			for (num6 = 0; num6 < nMTF; num6 = num8 + 1)
			{
				num8 = num6 + 50 - 1;
				if (num8 >= nMTF)
				{
					num8 = nMTF - 1;
				}
				for (int i = 0; i < num3; i++)
				{
					array4[i] = 0;
				}
				IntPtr intPtr;
				if (num3 == 6)
				{
					short num14;
					short num13;
					short num12;
					short num11;
					short num10;
					short num15 = num14 = (num13 = (num12 = (num11 = (num10 = 0))));
					for (int m = num6; m <= num8; m++)
					{
						short num16 = szptr[m];
						num15 = (short)(num15 + (short)array[0][num16]);
						num14 = (short)(num14 + (short)array[1][num16]);
						num13 = (short)(num13 + (short)array[2][num16]);
						num12 = (short)(num12 + (short)array[3][num16]);
						num11 = (short)(num11 + (short)array[4][num16]);
						num10 = (short)(num10 + (short)array[5][num16]);
					}
					array4[0] = num15;
					array4[1] = num14;
					array4[2] = num13;
					array4[3] = num12;
					array4[4] = num11;
					array4[5] = num10;
				}
				else
				{
					for (int m = num6; m <= num8; m++)
					{
						short num17 = szptr[m];
						for (int i = 0; i < num3; i++)
						{
							short[] array5;
							short[] array6 = array5 = array4;
							int num18 = i;
							intPtr = (IntPtr)num18;
							array6[num18] = (short)(array5[(long)intPtr] + (short)array[i][num17]);
						}
					}
				}
				int num19 = 999999999;
				int num20 = -1;
				for (int i = 0; i < num3; i++)
				{
					if (array4[i] < num19)
					{
						num19 = array4[i];
						num20 = i;
					}
				}
				num9 += num19;
				int[] array7;
				int[] array8 = array7 = array3;
				int num21 = num20;
				intPtr = (IntPtr)num21;
				array8[num21] = array7[(long)intPtr] + 1;
				selector[num] = (char)num20;
				num++;
				for (int m = num6; m <= num8; m++)
				{
					int[] array9 = array7 = array2[num20];
					short num22 = szptr[m];
					intPtr = (IntPtr)(void*)num22;
					array9[num22] = array7[(long)intPtr] + 1;
				}
			}
			for (int i = 0; i < num3; i++)
			{
				HbMakeCodeLengths(array[i], array2[i], num2, 20);
			}
		}
		array2 = null;
		array3 = null;
		array4 = null;
		if (num3 >= 8)
		{
			Panic();
		}
		if (num >= 32768 || num > 18002)
		{
			Panic();
		}
		char[] array10 = new char[6];
		for (int m = 0; m < num3; m++)
		{
			array10[m] = (char)m;
		}
		for (int m = 0; m < num; m++)
		{
			char c = selector[m];
			int num23 = 0;
			char c2 = array10[num23];
			while (c != c2)
			{
				num23++;
				char c3 = c2;
				c2 = array10[num23];
				array10[num23] = c3;
			}
			array10[0] = c2;
			selectorMtf[m] = (char)num23;
		}
		int[][] array11 = CBZip2InputStream.InitIntArray(6, 258);
		for (int i = 0; i < num3; i++)
		{
			int num24 = 32;
			int num25 = 0;
			for (int m = 0; m < num2; m++)
			{
				if (array[i][m] > num25)
				{
					num25 = array[i][m];
				}
				if (array[i][m] < num24)
				{
					num24 = array[i][m];
				}
			}
			if (num25 > 20)
			{
				Panic();
			}
			if (num24 < 1)
			{
				Panic();
			}
			HbAssignCodes(array11[i], array[i], num24, num25, num2);
		}
		bool[] array12 = new bool[16];
		for (int m = 0; m < 16; m++)
		{
			array12[m] = false;
			for (int num23 = 0; num23 < 16; num23++)
			{
				if (inUse[m * 16 + num23])
				{
					array12[m] = true;
				}
			}
		}
		for (int m = 0; m < 16; m++)
		{
			if (array12[m])
			{
				BsW(1, 1);
			}
			else
			{
				BsW(1, 0);
			}
		}
		for (int m = 0; m < 16; m++)
		{
			if (!array12[m])
			{
				continue;
			}
			for (int num23 = 0; num23 < 16; num23++)
			{
				if (inUse[m * 16 + num23])
				{
					BsW(1, 1);
				}
				else
				{
					BsW(1, 0);
				}
			}
		}
		BsW(3, num3);
		BsW(15, num);
		for (int m = 0; m < num; m++)
		{
			for (int num23 = 0; num23 < selectorMtf[m]; num23++)
			{
				BsW(1, 1);
			}
			BsW(1, 0);
		}
		for (int i = 0; i < num3; i++)
		{
			int n = array[i][0];
			BsW(5, n);
			for (int m = 0; m < num2; m++)
			{
				for (; n < array[i][m]; n++)
				{
					BsW(2, 2);
				}
				while (n > array[i][m])
				{
					BsW(2, 3);
					n--;
				}
				BsW(1, 0);
			}
		}
		int num26 = 0;
		num6 = 0;
		while (num6 < nMTF)
		{
			int num8 = num6 + 50 - 1;
			if (num8 >= nMTF)
			{
				num8 = nMTF - 1;
			}
			for (int m = num6; m <= num8; m++)
			{
				BsW(array[selector[num26]][szptr[m]], array11[selector[num26]][szptr[m]]);
			}
			num6 = num8 + 1;
			num26++;
		}
		if (num26 != num)
		{
			Panic();
		}
	}

	private void MoveToFrontCodeAndSend()
	{
		BsPutIntVS(24, origPtr);
		GenerateMTFValues();
		SendMTFValues();
	}

	private void SimpleSort(int lo, int hi, int d)
	{
		int num = hi - lo + 1;
		if (num < 2)
		{
			return;
		}
		int i;
		for (i = 0; incs[i] < num; i++)
		{
		}
		for (i--; i >= 0; i--)
		{
			int num2 = incs[i];
			int num3 = lo + num2;
			while (num3 <= hi)
			{
				int num4 = zptr[num3];
				int num5 = num3;
				while (FullGtU(zptr[num5 - num2] + d, num4 + d))
				{
					zptr[num5] = zptr[num5 - num2];
					num5 -= num2;
					if (num5 <= lo + num2 - 1)
					{
						break;
					}
				}
				zptr[num5] = num4;
				num3++;
				if (num3 > hi)
				{
					break;
				}
				num4 = zptr[num3];
				num5 = num3;
				while (FullGtU(zptr[num5 - num2] + d, num4 + d))
				{
					zptr[num5] = zptr[num5 - num2];
					num5 -= num2;
					if (num5 <= lo + num2 - 1)
					{
						break;
					}
				}
				zptr[num5] = num4;
				num3++;
				if (num3 > hi)
				{
					break;
				}
				num4 = zptr[num3];
				num5 = num3;
				while (FullGtU(zptr[num5 - num2] + d, num4 + d))
				{
					zptr[num5] = zptr[num5 - num2];
					num5 -= num2;
					if (num5 <= lo + num2 - 1)
					{
						break;
					}
				}
				zptr[num5] = num4;
				num3++;
				if (workDone > workLimit && firstAttempt)
				{
					return;
				}
			}
		}
	}

	private void Vswap(int p1, int p2, int n)
	{
		int num = 0;
		while (n > 0)
		{
			num = zptr[p1];
			zptr[p1] = zptr[p2];
			zptr[p2] = num;
			p1++;
			p2++;
			n--;
		}
	}

	private char Med3(char a, char b, char c)
	{
		if (a > b)
		{
			char c2 = a;
			a = b;
			b = c2;
		}
		if (b > c)
		{
			char c2 = b;
			b = c;
			c = c2;
		}
		if (a > b)
		{
			b = a;
		}
		return b;
	}

	private void QSort3(int loSt, int hiSt, int dSt)
	{
		StackElem[] array = new StackElem[1000];
		for (int i = 0; i < 1000; i++)
		{
			array[i] = new StackElem();
		}
		int num = 0;
		array[num].ll = loSt;
		array[num].hh = hiSt;
		array[num].dd = dSt;
		num++;
		while (num > 0)
		{
			if (num >= 1000)
			{
				Panic();
			}
			num--;
			int ll = array[num].ll;
			int hh = array[num].hh;
			int dd = array[num].dd;
			if (hh - ll < 20 || dd > 10)
			{
				SimpleSort(ll, hh, dd);
				if (workDone > workLimit && firstAttempt)
				{
					break;
				}
				continue;
			}
			int num2 = Med3(block[zptr[ll] + dd + 1], block[zptr[hh] + dd + 1], block[zptr[ll + hh >> 1] + dd + 1]);
			int num3;
			int num4 = num3 = ll;
			int num5;
			int num6 = num5 = hh;
			int num7;
			while (true)
			{
				if (num4 <= num6)
				{
					num7 = block[zptr[num4] + dd + 1] - num2;
					if (num7 == 0)
					{
						int num8 = 0;
						num8 = zptr[num4];
						zptr[num4] = zptr[num3];
						zptr[num3] = num8;
						num3++;
						num4++;
						continue;
					}
					if (num7 <= 0)
					{
						num4++;
						continue;
					}
				}
				while (num4 <= num6)
				{
					num7 = block[zptr[num6] + dd + 1] - num2;
					if (num7 == 0)
					{
						int num9 = 0;
						num9 = zptr[num6];
						zptr[num6] = zptr[num5];
						zptr[num5] = num9;
						num5--;
						num6--;
					}
					else
					{
						if (num7 < 0)
						{
							break;
						}
						num6--;
					}
				}
				if (num4 > num6)
				{
					break;
				}
				int num10 = zptr[num4];
				zptr[num4] = zptr[num6];
				zptr[num6] = num10;
				num4++;
				num6--;
			}
			if (num5 < num3)
			{
				array[num].ll = ll;
				array[num].hh = hh;
				array[num].dd = dd + 1;
				num++;
				continue;
			}
			num7 = ((num3 - ll < num4 - num3) ? (num3 - ll) : (num4 - num3));
			Vswap(ll, num4 - num7, num7);
			int num11 = (hh - num5 < num5 - num6) ? (hh - num5) : (num5 - num6);
			Vswap(num4, hh - num11 + 1, num11);
			num7 = ll + num4 - num3 - 1;
			num11 = hh - (num5 - num6) + 1;
			array[num].ll = ll;
			array[num].hh = num7;
			array[num].dd = dd;
			num++;
			array[num].ll = num7 + 1;
			array[num].hh = num11 - 1;
			array[num].dd = dd + 1;
			num++;
			array[num].ll = num11;
			array[num].hh = hh;
			array[num].dd = dd;
			num++;
		}
	}

	private void MainSort()
	{
		int[] array = new int[256];
		int[] array2 = new int[256];
		bool[] array3 = new bool[256];
		for (int i = 0; i < 20; i++)
		{
			block[last + i + 2] = block[i % (last + 1) + 1];
		}
		for (int i = 0; i <= last + 20; i++)
		{
			quadrant[i] = 0;
		}
		block[0] = block[last + 1];
		if (last < 4000)
		{
			for (int i = 0; i <= last; i++)
			{
				zptr[i] = i;
			}
			firstAttempt = false;
			workDone = (workLimit = 0);
			SimpleSort(0, last, 0);
			return;
		}
		int num = 0;
		for (int i = 0; i <= 255; i++)
		{
			array3[i] = false;
		}
		for (int i = 0; i <= 65536; i++)
		{
			ftab[i] = 0;
		}
		int num2 = block[0];
		int[] array4;
		IntPtr intPtr;
		for (int i = 0; i <= last; i++)
		{
			int num3 = block[i + 1];
			int[] array5 = array4 = ftab;
			int num4 = (num2 << 8) + num3;
			intPtr = (IntPtr)num4;
			array5[num4] = array4[(long)intPtr] + 1;
			num2 = num3;
		}
		for (int i = 1; i <= 65536; i++)
		{
			int[] array6 = array4 = ftab;
			int num5 = i;
			intPtr = (IntPtr)num5;
			array6[num5] = array4[(long)intPtr] + ftab[i - 1];
		}
		num2 = block[1];
		int num6;
		for (int i = 0; i < last; i++)
		{
			int num3 = block[i + 2];
			num6 = (num2 << 8) + num3;
			num2 = num3;
			int[] array7 = array4 = ftab;
			int num7 = num6;
			intPtr = (IntPtr)num7;
			array7[num7] = array4[(long)intPtr] - 1;
			zptr[ftab[num6]] = i;
		}
		num6 = (int)(((uint)block[last + 1] << 8) + block[1]);
		int[] array8 = array4 = ftab;
		int num8 = num6;
		intPtr = (IntPtr)num8;
		array8[num8] = array4[(long)intPtr] - 1;
		zptr[ftab[num6]] = last;
		for (int i = 0; i <= 255; i++)
		{
			array[i] = i;
		}
		int num9 = 1;
		do
		{
			num9 = 3 * num9 + 1;
		}
		while (num9 <= 256);
		do
		{
			num9 /= 3;
			for (int i = num9; i <= 255; i++)
			{
				int num10 = array[i];
				num6 = i;
				while (ftab[array[num6 - num9] + 1 << 8] - ftab[array[num6 - num9] << 8] > ftab[num10 + 1 << 8] - ftab[num10 << 8])
				{
					array[num6] = array[num6 - num9];
					num6 -= num9;
					if (num6 <= num9 - 1)
					{
						break;
					}
				}
				array[num6] = num10;
			}
		}
		while (num9 != 1);
		for (int i = 0; i <= 255; i++)
		{
			int num11 = array[i];
			for (num6 = 0; num6 <= 255; num6++)
			{
				int num12 = (num11 << 8) + num6;
				if ((ftab[num12] & 0x200000) == 2097152)
				{
					continue;
				}
				int num13 = ftab[num12] & -2097153;
				int num14 = (ftab[num12 + 1] & -2097153) - 1;
				if (num14 > num13)
				{
					QSort3(num13, num14, 2);
					num += num14 - num13 + 1;
					if (workDone > workLimit && firstAttempt)
					{
						return;
					}
				}
				int[] array9 = array4 = ftab;
				int num15 = num12;
				intPtr = (IntPtr)num15;
				array9[num15] = (array4[(long)intPtr] | 0x200000);
			}
			array3[num11] = true;
			if (i < 255)
			{
				int num16 = ftab[num11 << 8] & -2097153;
				int num17 = (ftab[num11 + 1 << 8] & -2097153) - num16;
				int j;
				for (j = 0; num17 >> j > 65534; j++)
				{
				}
				for (num6 = 0; num6 < num17; num6++)
				{
					int num18 = zptr[num16 + num6];
					int num19 = num6 >> j;
					quadrant[num18] = num19;
					if (num18 < 20)
					{
						quadrant[num18 + last + 1] = num19;
					}
				}
				if (num17 - 1 >> j > 65535)
				{
					Panic();
				}
			}
			for (num6 = 0; num6 <= 255; num6++)
			{
				array2[num6] = (ftab[(num6 << 8) + num11] & -2097153);
			}
			for (num6 = (ftab[num11 << 8] & -2097153); num6 < (ftab[num11 + 1 << 8] & -2097153); num6++)
			{
				num2 = block[zptr[num6]];
				if (!array3[num2])
				{
					zptr[array2[num2]] = ((zptr[num6] == 0) ? last : (zptr[num6] - 1));
					int[] array10 = array4 = array2;
					int num20 = num2;
					intPtr = (IntPtr)num20;
					array10[num20] = array4[(long)intPtr] + 1;
				}
			}
			for (num6 = 0; num6 <= 255; num6++)
			{
				int[] array11 = array4 = ftab;
				int num21 = (num6 << 8) + num11;
				intPtr = (IntPtr)num21;
				array11[num21] = (array4[(long)intPtr] | 0x200000);
			}
		}
	}

	private void RandomiseBlock()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 256; i++)
		{
			inUse[i] = false;
		}
		for (int i = 0; i <= last; i++)
		{
			if (num == 0)
			{
				num = (ushort)BZip2Constants.rNums[num2];
				num2++;
				if (num2 == 512)
				{
					num2 = 0;
				}
			}
			num--;
			char[] array;
			char[] array2 = array = block;
			int num3 = i + 1;
			IntPtr intPtr = (IntPtr)num3;
			array2[num3] = (char)(array[(long)intPtr] ^ (ushort)((num == 1) ? 1 : 0));
			char[] array3 = array = block;
			int num4 = i + 1;
			intPtr = (IntPtr)num4;
			array3[num4] = (char)(array[(long)intPtr] & 0xFF);
			inUse[block[i + 1]] = true;
		}
	}

	private void DoReversibleTransformation()
	{
		workLimit = workFactor * last;
		workDone = 0;
		blockRandomised = false;
		firstAttempt = true;
		MainSort();
		if (workDone > workLimit && firstAttempt)
		{
			RandomiseBlock();
			workLimit = (workDone = 0);
			blockRandomised = true;
			firstAttempt = false;
			MainSort();
		}
		origPtr = -1;
		for (int i = 0; i <= last; i++)
		{
			if (zptr[i] == 0)
			{
				origPtr = i;
				break;
			}
		}
		if (origPtr == -1)
		{
			Panic();
		}
	}

	private bool FullGtU(int i1, int i2)
	{
		char c = block[i1 + 1];
		char c2 = block[i2 + 1];
		if (c != c2)
		{
			return c > c2;
		}
		i1++;
		i2++;
		c = block[i1 + 1];
		c2 = block[i2 + 1];
		if (c != c2)
		{
			return c > c2;
		}
		i1++;
		i2++;
		c = block[i1 + 1];
		c2 = block[i2 + 1];
		if (c != c2)
		{
			return c > c2;
		}
		i1++;
		i2++;
		c = block[i1 + 1];
		c2 = block[i2 + 1];
		if (c != c2)
		{
			return c > c2;
		}
		i1++;
		i2++;
		c = block[i1 + 1];
		c2 = block[i2 + 1];
		if (c != c2)
		{
			return c > c2;
		}
		i1++;
		i2++;
		c = block[i1 + 1];
		c2 = block[i2 + 1];
		if (c != c2)
		{
			return c > c2;
		}
		i1++;
		i2++;
		int num = last + 1;
		do
		{
			c = block[i1 + 1];
			c2 = block[i2 + 1];
			if (c != c2)
			{
				return c > c2;
			}
			int num2 = quadrant[i1];
			int num3 = quadrant[i2];
			if (num2 != num3)
			{
				return num2 > num3;
			}
			i1++;
			i2++;
			c = block[i1 + 1];
			c2 = block[i2 + 1];
			if (c != c2)
			{
				return c > c2;
			}
			num2 = quadrant[i1];
			num3 = quadrant[i2];
			if (num2 != num3)
			{
				return num2 > num3;
			}
			i1++;
			i2++;
			c = block[i1 + 1];
			c2 = block[i2 + 1];
			if (c != c2)
			{
				return c > c2;
			}
			num2 = quadrant[i1];
			num3 = quadrant[i2];
			if (num2 != num3)
			{
				return num2 > num3;
			}
			i1++;
			i2++;
			c = block[i1 + 1];
			c2 = block[i2 + 1];
			if (c != c2)
			{
				return c > c2;
			}
			num2 = quadrant[i1];
			num3 = quadrant[i2];
			if (num2 != num3)
			{
				return num2 > num3;
			}
			i1++;
			i2++;
			if (i1 > last)
			{
				i1 -= last;
				i1--;
			}
			if (i2 > last)
			{
				i2 -= last;
				i2--;
			}
			num -= 4;
			workDone++;
		}
		while (num >= 0);
		return false;
	}

	private void AllocateCompressStructures()
	{
		int num = 100000 * blockSize100k;
		block = new char[num + 1 + 20];
		quadrant = new int[num + 20];
		zptr = new int[num];
		ftab = new int[65537];
		if (block != null && quadrant != null && zptr != null)
		{
			int[] ftab2 = ftab;
		}
		szptr = new short[2 * num];
	}

	private void GenerateMTFValues()
	{
		char[] array = new char[256];
		MakeMaps();
		int num = nInUse + 1;
		for (int i = 0; i <= num; i++)
		{
			mtfFreq[i] = 0;
		}
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < nInUse; i++)
		{
			array[i] = (char)i;
		}
		int[] array2;
		IntPtr intPtr;
		for (int i = 0; i <= last; i++)
		{
			char c = unseqToSeq[block[zptr[i]]];
			int num4 = 0;
			char c2 = array[num4];
			while (c != c2)
			{
				num4++;
				char c3 = c2;
				c2 = array[num4];
				array[num4] = c3;
			}
			array[0] = c2;
			if (num4 == 0)
			{
				num3++;
				continue;
			}
			if (num3 > 0)
			{
				num3--;
				while (true)
				{
					switch (num3 % 2)
					{
					case 0:
						szptr[num2] = 0;
						num2++;
						(array2 = mtfFreq)[0] = array2[0] + 1;
						break;
					case 1:
						szptr[num2] = 1;
						num2++;
						(array2 = mtfFreq)[1] = array2[1] + 1;
						break;
					}
					if (num3 < 2)
					{
						break;
					}
					num3 = (num3 - 2) / 2;
				}
				num3 = 0;
			}
			szptr[num2] = (short)(num4 + 1);
			num2++;
			int[] array3 = array2 = mtfFreq;
			int num5 = num4 + 1;
			intPtr = (IntPtr)num5;
			array3[num5] = array2[(long)intPtr] + 1;
		}
		if (num3 > 0)
		{
			num3--;
			while (true)
			{
				switch (num3 % 2)
				{
				case 0:
					szptr[num2] = 0;
					num2++;
					(array2 = mtfFreq)[0] = array2[0] + 1;
					break;
				case 1:
					szptr[num2] = 1;
					num2++;
					(array2 = mtfFreq)[1] = array2[1] + 1;
					break;
				}
				if (num3 < 2)
				{
					break;
				}
				num3 = (num3 - 2) / 2;
			}
		}
		szptr[num2] = (short)num;
		num2++;
		int[] array4 = array2 = mtfFreq;
		int num6 = num;
		intPtr = (IntPtr)num6;
		array4[num6] = array2[(long)intPtr] + 1;
		nMTF = num2;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return 0;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return 0L;
	}

	public override void SetLength(long value)
	{
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		for (int i = 0; i < count; i++)
		{
			WriteByte(buffer[i + offset]);
		}
	}
}

// CRC
internal class CRC
{
	public static readonly int[] crc32Table = new int[256]
	{
		0,
		79764919,
		159529838,
		222504665,
		319059676,
		398814059,
		445009330,
		507990021,
		638119352,
		583659535,
		797628118,
		726387553,
		890018660,
		835552979,
		1015980042,
		944750013,
		1276238704,
		1221641927,
		1167319070,
		1095957929,
		1595256236,
		1540665371,
		1452775106,
		1381403509,
		1780037320,
		1859660671,
		1671105958,
		1733955601,
		2031960084,
		2111593891,
		1889500026,
		1952343757,
		-1742489888,
		-1662866601,
		-1851683442,
		-1788833735,
		-1960329156,
		-1880695413,
		-2103051438,
		-2040207643,
		-1104454824,
		-1159051537,
		-1213636554,
		-1284997759,
		-1389417084,
		-1444007885,
		-1532160278,
		-1603531939,
		-734892656,
		-789352409,
		-575645954,
		-646886583,
		-952755380,
		-1007220997,
		-827056094,
		-898286187,
		-231047128,
		-151282273,
		-71779514,
		-8804623,
		-515967244,
		-436212925,
		-390279782,
		-327299027,
		881225847,
		809987520,
		1023691545,
		969234094,
		662832811,
		591600412,
		771767749,
		717299826,
		311336399,
		374308984,
		453813921,
		533576470,
		25881363,
		88864420,
		134795389,
		214552010,
		2023205639,
		2086057648,
		1897238633,
		1976864222,
		1804852699,
		1867694188,
		1645340341,
		1724971778,
		1587496639,
		1516133128,
		1461550545,
		1406951526,
		1302016099,
		1230646740,
		1142491917,
		1087903418,
		-1398421865,
		-1469785312,
		-1524105735,
		-1578704818,
		-1079922613,
		-1151291908,
		-1239184603,
		-1293773166,
		-1968362705,
		-1905510760,
		-2094067647,
		-2014441994,
		-1716953613,
		-1654112188,
		-1876203875,
		-1796572374,
		-525066777,
		-462094256,
		-382327159,
		-302564546,
		-206542021,
		-143559028,
		-97365931,
		-17609246,
		-960696225,
		-1031934488,
		-817968335,
		-872425850,
		-709327229,
		-780559564,
		-600130067,
		-654598054,
		1762451694,
		1842216281,
		1619975040,
		1682949687,
		2047383090,
		2127137669,
		1938468188,
		2001449195,
		1325665622,
		1271206113,
		1183200824,
		1111960463,
		1543535498,
		1489069629,
		1434599652,
		1363369299,
		622672798,
		568075817,
		748617968,
		677256519,
		907627842,
		853037301,
		1067152940,
		995781531,
		51762726,
		131386257,
		177728840,
		240578815,
		269590778,
		349224269,
		429104020,
		491947555,
		-248556018,
		-168932423,
		-122852000,
		-60002089,
		-500490030,
		-420856475,
		-341238852,
		-278395381,
		-685261898,
		-739858943,
		-559578920,
		-630940305,
		-1004286614,
		-1058877219,
		-845023740,
		-916395085,
		-1119974018,
		-1174433591,
		-1262701040,
		-1333941337,
		-1371866206,
		-1426332139,
		-1481064244,
		-1552294533,
		-1690935098,
		-1611170447,
		-1833673816,
		-1770699233,
		-2009983462,
		-1930228819,
		-2119160460,
		-2056179517,
		1569362073,
		1498123566,
		1409854455,
		1355396672,
		1317987909,
		1246755826,
		1192025387,
		1137557660,
		2072149281,
		2135122070,
		1912620623,
		1992383480,
		1753615357,
		1816598090,
		1627664531,
		1707420964,
		295390185,
		358241886,
		404320391,
		483945776,
		43990325,
		106832002,
		186451547,
		266083308,
		932423249,
		861060070,
		1041341759,
		986742920,
		613929101,
		542559546,
		756411363,
		701822548,
		-978770311,
		-1050133554,
		-869589737,
		-924188512,
		-693284699,
		-764654318,
		-550540341,
		-605129092,
		-475935807,
		-413084042,
		-366743377,
		-287118056,
		-257573603,
		-194731862,
		-114850189,
		-35218492,
		-1984365303,
		-1921392450,
		-2143631769,
		-2063868976,
		-1698919467,
		-1635936670,
		-1824608069,
		-1744851700,
		-1347415887,
		-1418654458,
		-1506661409,
		-1561119128,
		-1129027987,
		-1200260134,
		-1254728445,
		-1309196108
	};

	internal int globalCrc;

	public CRC()
	{
		InitialiseCRC();
	}

	internal void InitialiseCRC()
	{
		globalCrc = -1;
	}

	internal int GetFinalCRC()
	{
		return ~globalCrc;
	}

	internal int GetGlobalCRC()
	{
		return globalCrc;
	}

	internal void SetGlobalCRC(int newCrc)
	{
		globalCrc = newCrc;
	}

	internal void UpdateCRC(int inCh)
	{
		int num = (globalCrc >> 24) ^ inCh;
		if (num < 0)
		{
			num = 256 + num;
		}
		globalCrc = ((globalCrc << 8) ^ crc32Table[num]);
	}
}
