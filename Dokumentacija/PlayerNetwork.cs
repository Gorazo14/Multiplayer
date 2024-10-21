using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{

    // Initializing the network variable, and giving network permission to the host and client
    private NetworkVariable<MyCustomData> randomNumber = new NetworkVariable<MyCustomData>(new MyCustomData
    {
        _int = 56,
        _bool = false,
    }, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    // Writing in the console only once, where all variables have to be added
    public override void OnNetworkSpawn()
    {
        randomNumber.OnValueChanged += (MyCustomData previousValue, MyCustomData newValue) =>
        {
            Debug.Log(OwnerClientId + ": " + newValue._int + ": " + newValue._bool + ": " + newValue._string);
        };
    }

    // Createing the custom data type construct, where all variables have to be serialized
    public struct MyCustomData: INetworkSerializable
    {
        public int _int;
        public bool _bool;
        public FixedString128Bytes _string;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref _int);
            serializer.SerializeValue(ref _bool);
            serializer.SerializeValue(ref _string);
        }
    }

    private void Update()       
    {
        if (!IsOwner) return;

        Vector3 moveDir = new(0f, 0f, 0f);

        // Changing the values of the network variable
        if (Input.GetKeyDown(KeyCode.T))
        {
            randomNumber.Value = new MyCustomData
            {
                _int = Random.Range(0, 10),
                _bool = false,
                _string = "This is a custom message!",
            };
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDir.z += 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir.z -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x += 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x -= 1f;
        }

        float speed = 3f;

        transform.position += speed * Time.deltaTime * moveDir;
    }
}
