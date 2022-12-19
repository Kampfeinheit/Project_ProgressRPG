
using UnityEngine;
using BansheeGz.BGDatabase;
using UnityEngine.AddressableAssets;


namespace BG_Database
{
    public class BGDB_Addressable : MonoBehaviour
    {

        private void Start()
        {
            Addresable_Data();
        }

        private void Addresable_Data()
        {
            // Addresable 에서 Data를 받아온 뒤 Byte[] 변수에 할당
            var databaseData
            = Addressables
                .LoadAssetAsync<TextAsset>(BGLoaderForRepoCustom.CustomDatabaseGuid).WaitForCompletion().bytes;

            // 수동으로 콘텐츠 로드
            BGRepo.SetDefaultRepoContent(databaseData);
            BGRepo.Load();


            // Database에 접근 한뒤 데이터를 불러와서 쓰는 코드
            // 여기서부터는 Resourcs 로더와 같다.
            BGMetaEntity table = BGRepo.I["Test_Field"];
            BGEntity entity = table.GetEntity(1);

            float entityValue = entity.Get<float>("Damage");
            Debug.Log(entityValue);
        }
    }
}