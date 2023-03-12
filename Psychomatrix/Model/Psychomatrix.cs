using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Psychomatrix.Model
{
    class Psychomatrix
    {
        DateTime DateOfBirth { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public int Number4 { get; set; }
        public int Number5 { get; set; }
        public int Number6 { get; set; }
        public Psychomatrix(DateTime dateOfBirth) 
        {
            this.DateOfBirth = dateOfBirth;
        }
        public int GetDay() 
        {
            return Convert.ToInt16(DateOfBirth.Day);
        }
        public int GetMonth()
        {
            return Convert.ToInt16(DateOfBirth.Month);
        }
        public int GetYear()
        {
            return Convert.ToInt16(DateOfBirth.Year);
        }
        public void SetNumber1()
        {
            foreach (char c in Convert.ToString(GetDay()))
            {
                Number1 += Convert.ToInt16(c.ToString());
            }

            foreach (char c in Convert.ToString(GetMonth()))
            {
                Number1 += Convert.ToInt16(c.ToString());
            }

            foreach (char c in Convert.ToString(GetYear()))
            {
                Number1 += Convert.ToInt16(c.ToString());
            }
        }
        public void SetNumber2()
        {
            if (Number1 < 10)
            {
                Number2 = 0;
            }
            else
            {
                foreach (char c in Convert.ToString(Number1))
                {
                    Number2 += Convert.ToInt16(c.ToString());
                }
            }
        }
        public void SetNumber3() 
        {
            int decade = 0;
            if (GetDay() > 0 && GetDay() <= 10)
            {
                decade = 1;
            }
            if (GetDay() > 10 && GetDay() <= 20)
            {
                decade = 2;
            }
            if (GetDay() > 20 && GetDay() <= 30)
            {
                decade = 3;
            }
            if (GetDay() > 30)
            {
                decade = 4;
            }
            Number3 = Number1 - (2 * decade);
        }
        public void SetNumber4() 
        {
            if (Number3 < 10)
            {
                Number4 = 0;
            }
            else
            {
                foreach (char c in Convert.ToString(Number3))
                {
                    Number4 += Convert.ToInt16(c.ToString());
                }
            }
        }
        public void SetNumber5() 
        {
            Number5 = Number1 + Number3;
        }
        public void SetNumber6()
        {
            if (Number2 == 0 & Number4 == 0)
            {
                Number6 = 0;
            }
            else 
            {
                Number6 = Number2 + Number4;
            }
        }
        public void Calculate() 
        {
            SetNumber1();
            SetNumber2();
            SetNumber3();
            SetNumber4();
            SetNumber5();
            SetNumber6();
        }
        public string GetResult() 
        {
            return GetDay() + " "
                + GetMonth() + " "
                + GetYear() + " "
                + Number1.ToString() + " "
                + Number2.ToString() + " "
                + Number3.ToString() + " "
                + Number4.ToString() + " "
                + "(" + Number5.ToString() + " "
                + Number6.ToString() + ")" + " "
                ;
        }
        public List<int> GetFirstList()
        {
            List<int> values = new List<int>();

            values.Add(GetDay());
            values.Add(GetMonth());
            values.Add(GetYear());
            values.Add(Number1);
            values.Add(Number2);
            values.Add(Number3);
            values.Add(Number4);

            return values;
        }

        public List<int> GetSecondList()
        {
            List<int> values = new List<int>();

            values.Add(Number5);
            values.Add(Number6);

            return values;
        }

        public List<string> GetMatrix(List<int> values) 
        {
            List<string> result = new List<string>();

            for (int i = 0; i < 13; i++)
            {
                string temp = String.Empty;
                foreach (int k in values)
                {
                    if (k == i)
                    {
                        temp += (Convert.ToString(i));
                    }
                    else if (k > 13)
                    {
                        foreach (char c in Convert.ToString(k))
                        {
                            if (Convert.ToString(c) == Convert.ToString(i))
                            {
                                temp += (Convert.ToString(c));
                            }
                        }
                    }
                }
                result.Add(temp);
            }
            return result;
        }

        public List<string> GetSumMatrix(List<string> matrix)
        {

            List<string> result = new List<string>();
            List<int> intgr = new List<int>();
            List<string> strng = new List<string>();

            foreach (string value in matrix)
            {
                int number;

                bool success = int.TryParse(value, out number);
                if (success == true)
                {
                    intgr.Add(Convert.ToInt16(value));
                }
                else
                {
                    intgr.Add(0);
                }
            }

            string group0 = Convert.ToString(Convert.ToInt16(intgr[1] + intgr[2] + intgr[3]));
            string group1 = Convert.ToString(Convert.ToInt16(intgr[4] + intgr[5] + intgr[6]));
            string group2 = Convert.ToString(Convert.ToInt16(intgr[7] + intgr[8] + intgr[9]));
            string group3 = Convert.ToString(Convert.ToInt16(intgr[10] + intgr[11] + intgr[12]));

            strng.Add(group0);
            strng.Add(group1);
            strng.Add(group2);
            strng.Add(group3);

            foreach (string str in strng)
            {
                int val = 0;
                if (Convert.ToInt16(str) > 12)
                {
                    foreach (char c in str)
                    {
                        val += Convert.ToInt16(Convert.ToString(c));
                    }
                }
                else 
                {
                    val = Convert.ToInt16(str);
                }
                result.Add(Convert.ToString(val));
            }

            return result;
        }

        public List<string> GetColor(List<string> matrix)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < 13; i++)
            {
                if (i == 1 || i == 2 || i == 3)
                {
                    if (matrix[i] == "111"
                        || matrix[i] == "222"
                        || matrix[i] == "33")
                    {
                        result.Add("Green");
                    }
                    else if (matrix[i] == String.Empty)
                    {
                        result.Add("Red");
                    }
                    else
                    {
                        result.Add("Yellow");
                    }
                }
                else
                {
                    if (matrix[i] == Convert.ToString(i))
                    {
                        result.Add("Green");
                    }
                    else if (matrix[i] == String.Empty)
                    {
                        result.Add("Red");
                    }
                    else
                    {
                        result.Add("Yellow");
                    }
                }
            }
            
            return result;
        }

        public List<string> GetDesc(List<string> matrix)
        {
            List<string> result = new List<string>();

            if (matrix[0] != String.Empty)
            {
                result.Add("LINE 0 - past experience in the supersystem cycle. The level of past experience is the archetype from which the subject begins development, the degree of readiness to use past accumulations in systemic relations.The more digits 0, the greater the richness of past experience, but the greater the danger of the subject's conservatism, because he seeks to rely in his activity on past accumulations more than on the development of consciousness in the present; the less - on the contrary. Conservatism can manifest itself as a passage in life habits and traditions that proved their effectiveness yesterday, as a result of which they have today an appeal like a 'gilded cage'." + Environment.NewLine);
            }
            if (matrix[1] != String.Empty)
            {
                result.Add("Square 1 (1st determinant of the subject). Vital activity, flexibility in the realization of individual interests, actualization, while a manifestation of a certain degree of centrism, self, and leadership. The degree of impact on the environment and, at the same time, the dependence on material factors in the living space; the degree of perfection of the material(psychophysical) building and the form of organization of the elements of the structure, as well as creative activity, self - organization." + Environment.NewLine);
            }
            if (matrix[2] != String.Empty)
            {
                result.Add("Square 2. Interactions that give birth to emotional and sensory the beginning in the subject, the space of relationships, the unconscious causality of the manifestation of the sphere of desires, aspirations, spontaneous impulses and the degree of their control.The ability to interact, to properly organize relationships with the opposite sex, the ability to control their emotions as a consequence of self - acceptance." + Environment.NewLine);
            }
            if (matrix[3] != String.Empty)
            {
                result.Add("Square 3. Dynamism of processes in life, volitional active beginning, strength of attraction, will, determination, ability to mobilize in action, practicality as the ability to realize abilities; fussiness, selfishness, a certain level of aggression as 'excessive assertiveness'.The degree of expressiveness in a person's desire to purposefully acquire knowledge about the world around him, persistence and focus in this. This connects determinant 3 with the creative attitude to the profession." + Environment.NewLine);
            }
            if (matrix[4] != String.Empty)
            {
                result.Add("Square 4. As the causality of interaction - the degree of desire for novelty, reforms, transformation, transformation of consciousness, the ability to change the system, the degree of mental stability, contrast in the manifestation of the qualities of the subject in different situations.The ability to spontaneously express their feelings.Characterizes impulsiveness, ability to transformation of old forms into new non- standard thinking.Sex ratio(sex); rhythm of life, the degree of stability of the nervous system." + Environment.NewLine);
            }
            if (matrix[5] != String.Empty)
            {
                result.Add("Square 5. The degree of expansion of consciousness and the sphere of influence on the surrounding world, the space of inclusion in the conscious influence and management of the transition process to a qualitatively new level of system structures, organizational skills.The degree is determined human awareness of their needs and feelings, the wisdom of acceptance life circumstances.Sophistication of perception of the world around by improving mutual understanding in systemic relations, ability to integrate. Originality is revealed as an opportunity for creative realization as organizational skills, non - standard and creative solutions. Polar manifestation as a degree of distorted understanding of creativity that expressed in states of delight, pleasure, enjoyment." + Environment.NewLine);
            }
            if (matrix[6] != String.Empty)
            {
                result.Add("Square 6. Creative aspirations in multilevel relations, increased sensitivity, subconscious perception of others causal system relations, creativity of creation and management of qualitatively new interrelations, fast establishment of deep contacts with people.For creative people - graceful intuition, higher sensation; for the inactive -higher ignorance and delusion, lack of knowledge about ways of development, inability to apply knowledge to creativity in the world, euphoria, idealization, the use of abilities in the field of sensory illusions and material desires.Determines the search for the path of educational education, including subconscious perception of the harmony of the world around." + Environment.NewLine);
            }
            if (matrix[7] != String.Empty)
            {
                result.Add("Square 7. Mental abilities, intellectual receptivity, sociability, contact, initiative, flexibility of mind in the field of specific material affairs and actions, speed of reaction, clarity of thought, non - standard.Defines the creative orientation of the individual as the ability to flexible creative thinking, determining the level of intelligence.The degree of completeness of understanding of creativity in matter, the level of understanding of the essence of matter management, the superiority of the rational over the irrational." + Environment.NewLine);
            }
            if (matrix[8] != String.Empty)
            {
                result.Add("Square 8. Systematic, principles of structuring, the ability to synthesis, the degree of perception of a single system of development in any manifestations of the world, the ability to create an ordered system out of chaos, self - control, inner integrity, the core as the basis of life, introspection, discipline, experience, strategic thinking, in relations with the team - a manifestation of self, self - isolation.The ability of the subject to assess their qualities, which characterizes the principle of structuring a systems approach.The degree of knowledge of the motive of development, the manifestation of self - control, responsibility, the creation of prerequisites for the manifestation of creative thinking, vision of development prospects, integrity." + Environment.NewLine);
            }
            if (matrix[9] != String.Empty)
            {
                result.Add("Square 9. Active cognition of specific causal relationships, cognition of the intuitive, irrational, transcendental consciousness, synthesizing ability.Degree perfection of construction of worldview concepts, thought forms. Opportunity to use the accumulated experience for practical purposes, to actively learn synthesizing intuitive levels, realizing the ways of creativity, the manifestation of aesthetic taste, harmony, sense of humor." + Environment.NewLine);
            }
            if (matrix[10] != String.Empty)
            {
                result.Add("Square 10. The energy of the concentration of will directed to transformation of inefficient structures, will and influence on large masses of people.Creative or destructive force.the desire for possession for selfish purposes or creativity management, based on the purpose of a larger system.The ability to see your life as a whole, realizing and feeling the continuity of the flow of life events.Increased conflict as an initial and unconscious search for the most effective way of development through the destruction of the old form of imperfect life and the restoration of relations through creative collective thinking." + Environment.NewLine);
            }
            if (matrix[11] != String.Empty)
            {
                result.Add("Square 11. Transforming subconscious activity transmutation and transformation, a pronounced desire to know the direction of development of the supersystem, superdetailing, deepening in particular, sometimes to the detriment of the whole.The ability to holistically perceive the world and systemic relationships with people, to understand the harmony of communication a pair of opposites.The level of transformation of the collective - unconscious into the collective - conscious as the ability to creative group thinking, the ability to predict future events" + Environment.NewLine);
            }
            if (matrix[12] != String.Empty)
            {
                result.Add("Square 12. Understanding the higher laws of development, understanding of the highest goal, missionary work.The desire for generalization, synthesis of rational and irrational.Inability to live 'in a new way', when the old does not meet the urgent tasks of improvement, conflict in the team.The degree of independence of values and behavior of the subject from outside influence as the ability to give birth to new structured relationships, as interaction at a new level of emotional purity.This connects the determinant with emotionality, empathy." + Environment.NewLine);
            }

            return result;
        }

        public List<string> GetSumCellMatrix(List<String> matrix)
        {

            List<string> result = new List<string>();
            List<int> intgr = new List<int>();
            List<string> strng = new List<string>();

            foreach (string value in matrix)
            {
                int number;

                bool success = int.TryParse(value, out number);
                if (success == true)
                {
                    intgr.Add(Convert.ToInt16(value));
                }
                else
                {
                    intgr.Add(0);
                }
            }

            for (int i = 0; i < 13; i++)
            {
                int temp = 0;
                foreach (int k in intgr)
                {
                    foreach (char c in Convert.ToString(k))
                    {
                        if (Convert.ToString(c) == Convert.ToString(i))
                        {
                            temp = k.ToString().Length;
                        }
                    }
                }
                result.Add(Convert.ToString(temp));
            }

            return result;
        }

        public override string ToString()
        {
            return "1 number: " + Number1.ToString() + Environment.NewLine
                + "2 number: " + Number2.ToString() + Environment.NewLine
                + "3 number: " + Number3.ToString() + Environment.NewLine
                + "4 number: " + Number4.ToString() + Environment.NewLine
                + "5 number: " + Number5.ToString() + Environment.NewLine
                + "6 number: " + Number6.ToString() + Environment.NewLine
                + "Result: " + GetResult()
                ;
        }
    }
}
