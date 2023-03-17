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
        [Header("NPCのデータ"),SerializeField]
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

        [Header("アニメーター"),HideInInspector]
        public Animator Animator;


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
            //foreach (NPCState npc in _nPCData.ObservationalWorld)
            //{
            //    npc.NPCFlag.InitFlag();
            //}
            SetNPCData("basic");
        }

        /// <summary>
        /// NPCの状態を変更する
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetNPCData(string name, bool value = true)
        {
            foreach (NPCState npc in _nPCData.ObservationalWorld)
            {
                if (npc.Name == name)
                {
                    //フラグをOnにした時Dataを更新
                    if (value)
                    {
                        //_data.NPCFlag.SetFlagStatus(false);
                        _data = npc;
                    }
                    //npc.NPCFlag.SetFlagStatus(value);
                    return;
                }
                Debug.LogErrorFormat("{0}に{1}は存在しません", _nPCData.name,name);
            }
        }

        public virtual int WordTerm()
        {
            return 0;
        }

        public string Word(Func<int> i)
        {
            string word;

            word = _nPCData.NormalWords[i()].Word;

            return word;
        }

        public void ChangeWord()
        {
            Words.transform.localScale = _wordData.WordStates[0].TextBoxSize;
            Words.fontSize = _wordData.WordStates[0].FontSize;

            if (EmotionalWorld.activeInHierarchy) Words.text = _data.Word;
            else Words.text = Word(WordTerm);
        }

        #region INPC
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
        #endregion
    }
}