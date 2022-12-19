
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
            // Addresable ���� Data�� �޾ƿ� �� Byte[] ������ �Ҵ�
            var databaseData
            = Addressables
                .LoadAssetAsync<TextAsset>(BGLoaderForRepoCustom.CustomDatabaseGuid).WaitForCompletion().bytes;

            // �������� ������ �ε�
            BGRepo.SetDefaultRepoContent(databaseData);
            BGRepo.Load();


            // Database�� ���� �ѵ� �����͸� �ҷ��ͼ� ���� �ڵ�
            // ���⼭���ʹ� Resourcs �δ��� ����.
            BGMetaEntity table = BGRepo.I["Test_Field"];
            BGEntity entity = table.GetEntity(1);

            float entityValue = entity.Get<float>("Damage");
            Debug.Log(entityValue);
        }
    }
}