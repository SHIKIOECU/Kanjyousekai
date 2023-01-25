using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace NPC
{
    public class NPCBase : InteractMessage, INPC
    {
        //NPCの情報
        private NPCState _data = new NPCState();

        //NPCData
        [SerializeField]
        private NPCData _nPCData;

        //マスクスプライト
        private GameObject _maskSprite;

        //感情世界
        [SerializeField]
        private GameObject _emotionalWorld;

        //グラフィック
        [SerializeField]
        private SpriteRenderer _nPC;

        //セリフ
        [SerializeField]
        private TextMeshProUGUI _words;

        [Header("セリフのデータ"),SerializeField]
        private WordData _wordData;

        //アニメーター
        public Animator Animator;

        private int _wordIndex;

        

        public virtual void Start()
        {
            _maskSprite = transform.GetChild(1).gameObject;

            //基本のNPCデータに変更
            InitNPCData();

            //感情世界を見えなくする
            EmotionalWorld.SetActive(true);
            MaskSprite.SetActive(false);

            Animator = GetComponent<Animator>();
            ChangeWorld();
        }

        //NPCのフラグを初期化
        public void InitNPCData()
        {
            foreach (NPCState npc in _nPCData.NPCStates)
            {
                npc.NPCFlag.InitFlag();
            }
            SetNPCData("basic");
        }

        //NPCの状態を変更する
        public void SetNPCData(string name, bool value = true)
        {
            foreach (NPCState npc in _nPCData.NPCStates)
            {
                if (npc.Name == name)
                {
                    //フラグをOnにした時Dataを更新
                    if (value)
                    {
                        //_data.NPCFlag.SetFlagStatus(false);
                        _data = npc;
                    }
                    npc.NPCFlag.SetFlagStatus(value);
                    return;
                }
            }
        }

        public virtual int WordTerm()
        {
            return 0;
        }

        public string Word(Func<int> i)
        {
            string word;

            word = _nPCData.Words[i()].Word;

            //foreach (NPCWord nPCWord in _nPCData.Words)
            //{
            //    foreach (Term flag in nPCWord.Terms)
            //    {
            //        if (flag.IsCheck==flag.FlagData.IsOn&&nPCWord.Terms.Count>=0) word = nPCWord.Word;
            //    }
            //}

            //if (word == null) return _nPCData.Words[0].Word;
            return word;
        }

        public void ChangeWord()
        {
            Words.transform.localScale = _wordData.WordStates[0].TextBoxSize;
            Words.fontSize = _wordData.WordStates[0].FontSize;

            if (EmotionalWorld.activeInHierarchy) Words.text = _data.Word;
            else Words.text = Word(WordTerm);
        }

        //インターフェースの定義
        public NPCState INPCData => _data;

        public GameObject MaskSprite => _maskSprite;

        public GameObject EmotionalWorld => _emotionalWorld;

        public Sprite EmotionalWorldSprite => _data.EmotionalWorldSprite;

        public SpriteRenderer NPCSprite => _nPC;

        public TextMeshProUGUI Words => _words;


        public virtual void AppearanceWorld()
        {
            //EmotionalWorld.SetActive(true);
            MaskSprite.SetActive(true);
            ChangeWord();
            SoundManagerA.Instance.PlaySE(SoundManagerA.SE_List.Open_World);
        }

        public virtual void ChangeWorld()
        {
            //感情世界の画像を変更
            EmotionalWorld.GetComponent<SpriteRenderer>().sprite
                = EmotionalWorldSprite;

            ChangeWord();

            if (EmotionalWorld.activeInHierarchy) AppearanceWorld();
        }

        public virtual void DisappearanceWorld()
        {
            //EmotionalWorld.SetActive(false);
            MaskSprite.SetActive(false);
            ChangeWord();
            SoundManagerA.Instance.PlaySE(SoundManagerA.SE_List.Close_World);
        }        
    }
}