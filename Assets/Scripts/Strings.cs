using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Strings : MonoBehaviour {
    public AudioClip damage_enemy;
    public AudioClip damage_complete;
    public AudioClip critical_hit;
    public AudioClip special_sound;
    public AudioClip heal_sound;
    public AudioSource audioSource;
    public GameObject Player_object;
    public GameObject Enemy;
    public GameObject input_prefab;
    public GameObject inactive_prefab;
    public Sprite UpArrowInactive;
    public Sprite DownArrowInactive;
    public Sprite LeftArrowInactive;
    public Sprite RightArrowInactive;
    public GameObject Special;
    bool up_passed;
    bool down_passed;
    Sprite[] inactive_sprites;
    public Sprite[] input_sprites;
    // string[] inputs = { "up", "down", "left", "right" };
    int input_length = 4;
    // int input_damage = 10;
    // int input_complete_damage = 15;
    float input_self_damage = 1.0f;
    //public Sprite[] string_array = new Sprite[5];
    int up_active = 0;
    int down_active = 0;
    int red_key_exists = 0;
    int green_key_exists = 0;
    List<Sprite> string_array = new List<Sprite>();
    List<Sprite> string_array_up = new List<Sprite>();
    List<Sprite> string_array_down = new List<Sprite>();
    List<GameObject> object_array = new List<GameObject>();
    List<GameObject> object_array_up = new List<GameObject>();
    List<GameObject> object_array_down = new List<GameObject>();
    List<GameObject> inactive_array = new List<GameObject>();
    public GameObject Main;
    public bool CLEARING = false;
    public bool complete_string = false;
    public Swipe swipeControls;

    public GameObject combo_value_object;
    public GameObject combo_multi_object;

    void Update()
    {
        if (swipeControls.SwipeUp)
        {
            Debug.Log("swipeup");
            check_input("UpArrow");
        }
        if (swipeControls.SwipeDown)
        {
            Debug.Log("swipedown");
            check_input("DownArrow");
        }
        if (swipeControls.SwipeLeft)
        {
            Debug.Log("swipeleft");
            check_input("LeftArrow");
        }
        if (swipeControls.SwipeRight)
        {
            Debug.Log("swiperight");
            check_input("RightArrow");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Debug.Log("Up arrow");
            string returned = check_input("UpArrow");
            if(returned == "UpArrow")
            {
                Player_object.GetComponent<Player>().player_animator.SetTrigger("upatk");
                // combo_value_object.GetComponent<combo_value>().increase_combo();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Debug.Log("Down arrow");
            string returned = check_input("DownArrow");
            if(returned == "DownArrow")
            {
                Player_object.GetComponent<Player>().player_animator.SetTrigger("downatk");
                // combo_value_object.GetComponent<combo_value>().increase_combo();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Debug.Log("Left arrow");
            string returned = check_input("LeftArrow");
            if(returned == "LeftArrow")
            {
                Player_object.GetComponent<Player>().player_animator.SetTrigger("fatk");
                // combo_value_object.GetComponent<combo_value>().increase_combo();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Debug.Log("Right arrow");
            string returned = check_input("RightArrow");
            if(returned == "RightArrow")
            {
                Player_object.GetComponent<Player>().player_animator.SetTrigger("fatk");
                // combo_value_object.GetComponent<combo_value>().increase_combo();
            }   
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Special.GetComponent<Special>().SPECIAL >= 30)
            {
                StartCoroutine(activate_special());
            }
        }
    }

    public string check_input(string arrow_input)
    {
        bool correct = false;
        CLEARING = false;
        complete_string = false;
        Debug.Log(up_active + "upactive");
        Debug.Log(down_active + "downactive");
        if ((object_array[0].name == "RightArrow") && (up_active == 0))
        {
            if ((arrow_input.ToString() == "UpArrow") && (up_passed == false))
            {
                up_passed = false;
                down_passed = true;
                up_active = 1;
            } else {
                up_passed = true;
            }
        }
        if (object_array_up.Count > 0)
        {
            if ((arrow_input.ToString() != object_array_up[0].name) && (up_active == 1) && (CLEARING == false))
            {
                CLEARING = true;
                Debug.Log("Incorrect, upactive");
                apply_player_damage();
                clear_string();
                create_string();
            }
            if ((arrow_input.ToString() == object_array_up[0].name) && (up_active == 1) && (object_array_up.Count > 0) && (CLEARING == false))
            {
                GameObject gameobject = object_array_up[0];
                if (Main.GetComponent<Main>().enemy_array.Count > 0)
                {
                    move_arrows();
                }
                if (gameobject.GetComponent<SpriteRenderer>().color == new Color(255, 0, 0))
                {
                    red_key_exists = 0;
                }
                if (gameobject.GetComponent<SpriteRenderer>().color == new Color(0, 255, 0))
                {
                    green_key_exists = 0;
                    Debug.Log("green");
                    heal_player(5);
                }
                object_array_up.RemoveAt(0);
                string_array_up.RemoveAt(0);
                Destroy(gameobject);
                if ((object_array_up.Count < 1) && (CLEARING == false))
                {
                    CLEARING = true;
                    apply_enemy_damage(true);
                    clear_string();
                    create_string();
                }
                else
                {
                    apply_enemy_damage(false);
                }
                if (CLEARING == false)
                {
                    make_first_key_yellow(object_array_up, object_array, object_array_down);
                }
                correct = true;

            }
        }
        if ((object_array[0].name == "LeftArrow") && (down_active == 0))
        {
            if ((arrow_input.ToString() == "DownArrow") && (down_passed == false))
            {
                Debug.Log("downpassedtrue");
                up_passed = true;
                down_passed = false;
                down_active = 1;
            } else {
                down_passed = true;
            }
        }
        if (object_array_down.Count > 0)
        {
            if ((arrow_input.ToString() != object_array_down[0].name) && (down_active == 1) && (CLEARING == false))
            {
                CLEARING = true;
                Debug.Log("Incorrect, down active");
                apply_player_damage();
                clear_string();
                create_string();
            }
            if ((arrow_input.ToString() == object_array_down[0].name) && (object_array_down.Count > 0) && (down_active == 1) && (CLEARING == false))
            {
                GameObject gameobject = object_array_down[0];
                if (Main.GetComponent<Main>().enemy_array.Count > 0)
                {
                    move_arrows();
                }
                if (gameobject.GetComponent<SpriteRenderer>().color == new Color(255, 0, 0))
                {
                    red_key_exists = 0;
                }
                if (gameobject.GetComponent<SpriteRenderer>().color == new Color(0, 255, 0))
                {
                    green_key_exists = 0;
                    heal_player(5);
                }
                object_array_down.RemoveAt(0);
                string_array_down.RemoveAt(0);
                Destroy(gameobject);
                if ((object_array_down.Count < 1) && (CLEARING == false))
                {
                    CLEARING = true;
                    apply_enemy_damage(true);
                    clear_string();
                    create_string();

                }
                else
                {
                    apply_enemy_damage(false);
  
                }
                if (CLEARING == false)
                {
                    make_first_key_yellow(object_array_down, object_array, object_array_up);
                }
                correct = true;
            }
        }
        if ((down_active == 0) && (up_active == 0))
        {
            if ((arrow_input.ToString() != object_array[0].name) && (CLEARING == false))
            {
                CLEARING = true;
                Debug.Log("Incorrect, normal");
                apply_player_damage();
                clear_string();
                create_string();
            }
            if ((arrow_input.ToString() == object_array[0].name) && (CLEARING == false))
            {
                GameObject gameobject = object_array[0];
                if (Main.GetComponent<Main>().enemy_array.Count > 0)
                {
                    move_arrows();
                }
                if (gameobject.GetComponent<SpriteRenderer>().color == new Color(255, 0, 0))
                {
                    red_key_exists = 0;
                }
                if (gameobject.GetComponent<SpriteRenderer>().color == new Color(0, 255, 0))
                {
                    green_key_exists = 0;
                    heal_player(5);
                }
                object_array.RemoveAt(0);
                string_array.RemoveAt(0);
                Destroy(gameobject);
                if ((object_array.Count < 1) && (CLEARING == false))
                {
                    CLEARING = true;
                    apply_enemy_damage(true);
                    clear_string();
                    create_string();
                }
                else
                {
                    apply_enemy_damage(false);
                }
                correct = true;
            }
            make_first_key_yellow(object_array, object_array_up, object_array_down);
        if((object_array_down.Count > 0) && (down_active == 0) && (down_passed == false) ){
            if((object_array[0].name == "LeftArrow") && (object_array_down[0].name == "DownArrow") && (down_active == 0)){
                make_first_key_yellow(object_array_down);
                }
            }
        if((object_array_up.Count > 0) && (up_active == 0) && (up_passed == false)){
            if((object_array[0].name == "RightArrow") && (object_array_up[0].name == "UpArrow") && (up_active == 0)){
                make_first_key_yellow(object_array_up);
                }
            }
        }   
    
        CLEARING = false;
        if(correct == true)
        {
            return arrow_input;
        }
        else
        {
            return "nothing";
        }
    }

    public void move_arrows()
    {
        if (object_array[0].name == "UpArrow")
        {
            GameObject inactiveprefab = Instantiate(inactive_prefab, new Vector3(object_array[0].transform.position.x , object_array[0].transform.position.y, object_array[0].transform.position.z), Quaternion.identity);
            inactiveprefab.GetComponent<SpriteRenderer>().sprite = UpArrowInactive;
            inactive_array.Add(inactiveprefab);
        }
        if (object_array_up.Count > 0 && up_active == 1){
            if (object_array_up[0].name == "UpArrow")
            {
                GameObject inactiveprefab = Instantiate(inactive_prefab, new Vector3(object_array_up[0].transform.position.x , object_array_up[0].transform.position.y, object_array_up[0].transform.position.z), Quaternion.identity);
                inactiveprefab.GetComponent<SpriteRenderer>().sprite = UpArrowInactive;
                inactive_array.Add(inactiveprefab);
            }
        }
        if (object_array_down.Count > 0 && down_active == 1){
            if (object_array_down[0].name == "UpArrow")
            {
                GameObject inactiveprefab = Instantiate(inactive_prefab, new Vector3(object_array_down[0].transform.position.x , object_array_down[0].transform.position.y, object_array_down[0].transform.position.z), Quaternion.identity);
                inactiveprefab.GetComponent<SpriteRenderer>().sprite = UpArrowInactive;
                inactive_array.Add(inactiveprefab);
            }
        }
        if (object_array[0].name == "DownArrow")
        {
            GameObject inactiveprefab = Instantiate(inactive_prefab, new Vector3(object_array[0].transform.position.x, object_array[0].transform.position.y, object_array[0].transform.position.z), Quaternion.identity);
            inactiveprefab.GetComponent<SpriteRenderer>().sprite = DownArrowInactive;
            inactive_array.Add(inactiveprefab);
        }
        if (object_array_up.Count > 0 && up_active == 1){
            if (object_array_up[0].name == "DownArrow")
            {
                GameObject inactiveprefab = Instantiate(inactive_prefab, new Vector3(object_array_up[0].transform.position.x , object_array_up[0].transform.position.y, object_array_up[0].transform.position.z), Quaternion.identity);
                inactiveprefab.GetComponent<SpriteRenderer>().sprite = DownArrowInactive;
                inactive_array.Add(inactiveprefab);
            }
        }
        if (object_array_down.Count > 0 && down_active == 1){
            if (object_array_down[0].name == "DownArrow")
            {
                GameObject inactiveprefab = Instantiate(inactive_prefab, new Vector3(object_array_down[0].transform.position.x , object_array_down[0].transform.position.y, object_array_down[0].transform.position.z), Quaternion.identity);
                inactiveprefab.GetComponent<SpriteRenderer>().sprite = DownArrowInactive;
                inactive_array.Add(inactiveprefab);
            }
        }
        if (object_array[0].name == "LeftArrow")
        {
            GameObject inactiveprefab = Instantiate(inactive_prefab, new Vector3(object_array[0].transform.position.x, object_array[0].transform.position.y, object_array[0].transform.position.z), Quaternion.identity);
            inactiveprefab.GetComponent<SpriteRenderer>().sprite = LeftArrowInactive;
            inactive_array.Add(inactiveprefab);
        }
        if (object_array_up.Count > 0 && up_active == 1){
            if (object_array_up[0].name == "LeftArrow")
            {
                GameObject inactiveprefab = Instantiate(inactive_prefab, new Vector3(object_array_up[0].transform.position.x , object_array_up[0].transform.position.y, object_array_up[0].transform.position.z), Quaternion.identity);
                inactiveprefab.GetComponent<SpriteRenderer>().sprite = LeftArrowInactive;
                inactive_array.Add(inactiveprefab);
            }
        }
        if (object_array_down.Count > 0 && down_active == 1){
            if (object_array_down[0].name == "LeftArrow")
            {
                GameObject inactiveprefab = Instantiate(inactive_prefab, new Vector3(object_array_down[0].transform.position.x , object_array_down[0].transform.position.y, object_array_down[0].transform.position.z), Quaternion.identity);
                inactiveprefab.GetComponent<SpriteRenderer>().sprite = LeftArrowInactive;
                inactive_array.Add(inactiveprefab);
            }
        }
        if (object_array[0].name == "RightArrow")
        {
            GameObject inactiveprefab = Instantiate(inactive_prefab, new Vector3(object_array[0].transform.position.x, object_array[0].transform.position.y, object_array[0].transform.position.z), Quaternion.identity);
            inactiveprefab.GetComponent<SpriteRenderer>().sprite = RightArrowInactive;
            inactive_array.Add(inactiveprefab);
        }
        if (object_array_up.Count > 0 && up_active == 1){
            if (object_array_up[0].name == "RightArrow")
            {
                GameObject inactiveprefab = Instantiate(inactive_prefab, new Vector3(object_array_up[0].transform.position.x , object_array_up[0].transform.position.y, object_array_up[0].transform.position.z), Quaternion.identity);
                inactiveprefab.GetComponent<SpriteRenderer>().sprite = RightArrowInactive;
                inactive_array.Add(inactiveprefab);
            }
        }
        if (object_array_down.Count > 0 && down_active == 1){
            if (object_array_down[0].name == "RightArrow")
            {
                GameObject inactiveprefab = Instantiate(inactive_prefab, new Vector3(object_array_down[0].transform.position.x , object_array_down[0].transform.position.y, object_array_down[0].transform.position.z), Quaternion.identity);
                inactiveprefab.GetComponent<SpriteRenderer>().sprite = RightArrowInactive;
                inactive_array.Add(inactiveprefab);
            }
        }

        foreach(GameObject gameobject2 in object_array)
        {
            Vector3 new_pos = Vector3.MoveTowards(gameobject2.transform.position, new Vector3(gameobject2.transform.position.x - 1.2f, gameobject2.transform.position.y, gameobject2.transform.position.z), 1.2f);
            gameobject2.transform.position = new_pos;
            // if(up_active == 1 || down_active == 1){
            //     gameobject2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
            // }
        }
        foreach(GameObject sprite2 in inactive_array)
        {
            Vector3 new_pos = Vector3.MoveTowards(sprite2.transform.position, new Vector3(sprite2.transform.position.x - 1.2f, sprite2.transform.position.y, sprite2.transform.position.z), 1.2f);
            sprite2.transform.position = new_pos;
        }
        foreach(GameObject gameobject3 in object_array_up)
        {
            Vector3 new_pos = Vector3.MoveTowards(gameobject3.transform.position, new Vector3(gameobject3.transform.position.x - 1.2f, gameobject3.transform.position.y, gameobject3.transform.position.z), 1.2f);
            gameobject3.transform.position = new_pos;
        }
        foreach(GameObject gameobject4 in object_array_down)
        {
            Vector3 new_pos = Vector3.MoveTowards(gameobject4.transform.position, new Vector3(gameobject4.transform.position.x - 1.2f, gameobject4.transform.position.y, gameobject4.transform.position.z), 1.2f);
            gameobject4.transform.position = new_pos;
        }

    }

    public void apply_enemy_damage(bool deal_complete)
    {
        bool crit = false;
        int player_LUK = Player_object.GetComponent<Player>().LUK;
        int player_CRIT = Player_object.GetComponent<Player>().CRIT_CHANCE;
        int player_STR = Player_object.GetComponent<Player>().STR;
        float total_default_damage = Player.default_attack + (Random.Range(Player.default_attack_min, Player.default_attack_max));
        int STR = player_STR;
        int total_damage = Mathf.RoundToInt((STR * 0.5f) + total_default_damage);
        int total_complete_damage = total_damage + Mathf.RoundToInt(Player.default_complete_damage);
        total_damage = Mathf.RoundToInt(total_damage * (float)(1.00 + (float)combo_value_object.GetComponent<combo_value>().combo1 / 100));
        if (Random.Range(0.00f, 101) <= (player_CRIT + (player_LUK * 0.05)))
        {
            total_complete_damage *= 2;
            total_damage *= 2;
            crit = true;
        }
        if (deal_complete == true)
        {
            Debug.Log(deal_complete);
            complete_string = true;
            if (crit == true){
                audioSource.PlayOneShot(critical_hit);
            } else {
                audioSource.PlayOneShot(damage_complete);
            }
            string isdead = Enemy.GetComponent<Enemy>().Damage(total_complete_damage, crit);
            if(isdead == "dead")
            {
                red_key_exists = 0;
            }
        }
        else
        {
            if (crit == true){
                audioSource.PlayOneShot(critical_hit);
            } else {
                audioSource.PlayOneShot(damage_enemy);
            }
            string isdead = Enemy.GetComponent<Enemy>().Damage(total_damage, crit);
            if(isdead == "dead")
            {
                red_key_exists = 0;
            }
        }
        combo_value_object.GetComponent<combo_value>().increase_combo();
        combo_multi_object.GetComponent<Animator>().SetTrigger("combomulti");
        Special.GetComponent<Special>().increase_special();
    }

    public void apply_player_damage()
    {
        float player_damage = input_self_damage;
        Player_object.GetComponent<Player>().Damage(player_damage);
        Special.GetComponent<Special>().reset_special();
        combo_value_object.GetComponent<combo_value>().reset_combo();
    }

    public void heal_player(int heal_amount)
    {
        audioSource.PlayOneShot(heal_sound);
        Player_object.GetComponent<Player>().heal(heal_amount);
    }

    public IEnumerator activate_special()
    {
        audioSource.PlayOneShot(special_sound);
        yield return new WaitForSeconds(0.7f);
        for(int i = 0; i < 40; i++)
        {
            red_key_exists = 0;
            if(down_active == 1)
            {
                check_input(object_array_down[0].name);
            } else {
                if(up_active == 1)
                {
                    check_input(object_array_up[0].name);
                } else {
                    check_input(object_array[0].name);
                }
            }
            // apply_enemy_damage(true);
            yield return new WaitForSeconds(0.05f);
        }
        Special.GetComponent<Special>().reset_special();
    }

    public void create_key(Sprite sprite, float x)
    {

        Sprite input_sprite = sprite;
        string input_name = input_sprite.name;

        GameObject newInput = Instantiate(input_prefab);
        newInput.name = input_name;
        newInput.GetComponent<single_input>().input_name = input_name;
        newInput.GetComponent<SpriteRenderer>().sprite = input_sprite;
        newInput.GetComponent<single_input>().x = x;
        object_array.Add(newInput);
    }

    public void make_first_key_yellow(List<GameObject> array, List<GameObject> array2 = null, List<GameObject> array3 = null)
    {
        if (array.Count > 0)
        {
            if(array[0].GetComponent<SpriteRenderer>().color == new Color(255, 0, 0) || array[0].GetComponent<SpriteRenderer>().color == new Color(0, 255, 0)){
                Debug.Log("that is coloured");
            } else {
                array[0].GetComponent<SpriteRenderer>().color = new Color(255, 255, 0);
            }
            if ((array2 != null) && (array2.Count > 0)){
                array2[0].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            }
            if ((array3 != null) && (array3.Count > 0)){
                array3[0].GetComponent<SpriteRenderer>().color = new Color(255,255,255);
            }
        }
    }

    public void create_string ()
    {
        // complete_string = false;
        up_passed = false;
        down_passed = false;
        float x = -7;
        
        string_array_up.Add(input_sprites[0]);
        string_array_down.Add(input_sprites[1]);
        for (int i = 0; i < input_length; i++)
        {
            string_array.Add(input_sprites[Random.Range(0, 4)]);
        }
        for(int i = 0; i < input_length - 2; i++)
        {
            string_array_up.Add(input_sprites[Random.Range(0, 4)]);
            string_array_down.Add(input_sprites[Random.Range(0, 4)]);
        }

        foreach(Sprite sprite in string_array)
        {
            x += 1.2f;
            create_key(sprite, x);
        }
        make_first_key_yellow(object_array);
        int left_found = 0;
        int right_found = 0;
        foreach (GameObject gameObject in object_array)
        {
            if ((gameObject.name == "RightArrow") && (right_found == 0))
            {
                right_found += 1;
                x = gameObject.GetComponent<single_input>().x;
                foreach(Sprite sprite in string_array_up)
                {

                    create_key_y(sprite, x, gameObject.name);
                    x += 1.2f;
                }
            }
            if ((gameObject.name == "LeftArrow") && (left_found == 0))
            {
                left_found += 1;
                x = gameObject.GetComponent<single_input>().x;
                foreach(Sprite sprite in string_array_down)
                {
                    create_key_y(sprite, x, gameObject.name);
                    x += 1.2f;
                }
            }
        }
        create_red_key();
        create_green_key();

    }

    public void create_string_magic(string magic)
    {
        clear_string();
        float x = -7;
        for (int i = 0; i < 6; i++)
        {
            string_array.Add(input_sprites[Random.Range(0,4)]);
        }
        foreach(Sprite sprite in string_array)
        {
            x += 1.2f;
            create_key(sprite, x);
        }
        // make it so that we know its a magic string lol idk
        make_first_key_yellow(object_array);
    }

    public void create_red_key()
    {
        int which_string_red = Random.Range(0, 3);
        if(which_string_red == 0){
            object_array[Random.Range(1, (object_array.Count - 1))].GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            red_key_exists = 1;
        }
        if((which_string_red == 1) && (object_array_up.Count > 0) ){
            object_array_up[Random.Range(1, (object_array_up.Count - 1))].GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            red_key_exists = 1;
        }
        if((which_string_red == 2) && (object_array_down.Count > 0)){
            object_array_down[Random.Range(1, (object_array_down.Count - 1))].GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            red_key_exists = 1;
        }
    }

    public void create_green_key()
    {
        int which_string_green = Random.Range(0, 5);
        if(which_string_green == 0){
            int which_key = Random.Range(1, object_array.Count - 1);
            if(object_array[which_key].GetComponent<SpriteRenderer>().color != new Color (255, 0, 0))
            {
                object_array[which_key].GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                green_key_exists = 1;
            }
        }
        if((which_string_green == 1) && (object_array_up.Count > 0) ){
            int which_key = Random.Range(1, object_array.Count - 1);
            if(object_array_up[which_key].GetComponent<SpriteRenderer>().color != new Color (255, 0, 0))
            {
                object_array_up[which_key].GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                green_key_exists = 1;
            }
        }
        if((which_string_green == 2) && (object_array_down.Count > 0)){
            int which_key = Random.Range(1, object_array.Count - 1);
            if(object_array_down[which_key].GetComponent<SpriteRenderer>().color != new Color (255, 0, 0))
            {
                object_array_down[which_key].GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                green_key_exists = 1;
            }
        }
    }

    public void create_key_y(Sprite sprite, float x, string gameObject_name)
    {
        if (gameObject_name == "RightArrow")
        {

            Sprite input_sprite = sprite;
            string input_name = input_sprite.name;
            GameObject newInput = Instantiate(input_prefab);
            newInput.name = input_name;
            newInput.GetComponent<single_input>().input_name = input_name;
            newInput.GetComponent<SpriteRenderer>().sprite = input_sprite;
            newInput.GetComponent<single_input>().x = x;
            newInput.GetComponent<single_input>().y = 1.3f;
            object_array_up.Add(newInput);
            object_array_up[0].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }
        if (gameObject_name == "LeftArrow")
        {
            Sprite input_sprite = sprite;
            string input_name = input_sprite.name;
            GameObject newInput = Instantiate(input_prefab);
            newInput.name = input_name;
            newInput.GetComponent<single_input>().input_name = input_name;
            newInput.GetComponent<SpriteRenderer>().sprite = input_sprite;
            newInput.GetComponent<single_input>().x = x;
            newInput.GetComponent<single_input>().y = -1.3f;
            object_array_down.Add(newInput);
            object_array_down[0].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }

    }

    public void clear_string()
    {
        if (red_key_exists == 1)
        {
            apply_player_damage();
        }
        foreach (GameObject gameObject in object_array)
        {
            Destroy(gameObject);
        }
        foreach (GameObject gameObject2 in inactive_array)
        {
            Destroy(gameObject2);
        }
        foreach (GameObject gameObject3 in object_array_up)
        {
            Destroy(gameObject3);
        }
        foreach (GameObject gameObject4 in object_array_down)
        {
            Destroy(gameObject4);
        }
        inactive_array.Clear();
        object_array.Clear();
        object_array_up.Clear();
        object_array_down.Clear();
        string_array.Clear();
        string_array_up.Clear();
        string_array_down.Clear();
        up_active = 0;
        down_active = 0;
        red_key_exists = 0;
        green_key_exists = 0;
        up_passed = false;
        down_passed = false;
    }





    // public void create_single_key()
    // {
    //     int random_index = Random.Range(0, input_sprites.Length);
    //     Sprite input_sprite = input_sprites[random_index];
    //     string input_name = input_sprite.name;

    //     GameObject newInput = Instantiate(input_prefab);
    //     newInput.name = input_name;
    //     newInput.GetComponent<single_input>().input_name = input_name;
    //     newInput.GetComponent<SpriteRenderer>().sprite = input_sprite;
    // }
}
